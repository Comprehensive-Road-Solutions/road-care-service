using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Data;
using System.Text;

using RoadCareService.Assignment.Application.Internal.CommandServices;
using RoadCareService.Assignment.Application.Internal.QueryServices;
using RoadCareService.Assignment.Domain.Repositories;
using RoadCareService.Assignment.Domain.Services.AssignmentWorker;
using RoadCareService.Assignment.Domain.Services.GovernmentEntity;
using RoadCareService.Assignment.Domain.Services.WorkerArea;
using RoadCareService.Assignment.Domain.Services.WorkerRole;
using RoadCareService.Assignment.Infrastructure.Persistence.EFC.Repositories;

using RoadCareService.IAM.Application.Internal.CommandServices;
using RoadCareService.IAM.Application.Internal.OutboundServices;
using RoadCareService.IAM.Application.Internal.QueryServices;
using RoadCareService.IAM.Domain.Repositories;
using RoadCareService.IAM.Domain.Services.Citizen;
using RoadCareService.IAM.Domain.Services.CitizenCredential;
using RoadCareService.IAM.Domain.Services.Worker;
using RoadCareService.IAM.Domain.Services.WorkerCredential;
using RoadCareService.IAM.Interfaces.ACL;
using RoadCareService.IAM.Interfaces.ACL.Services;
using RoadCareService.IAM.Infrastructure.Hashing.Argon2id;
using RoadCareService.IAM.Infrastructure.Persistence.EFC.Repositories;
using RoadCareService.IAM.Infrastructure.Pipeline.Middleware.Extensions;
using RoadCareService.IAM.Infrastructure.Request;
using RoadCareService.IAM.Infrastructure.Token.JWT.Configuration;
using RoadCareService.IAM.Infrastructure.Token.JWT.Services;

using RoadCareService.Interaction.Application.Internal.CommandServices;
using RoadCareService.Interaction.Application.Internal.QueryServices;
using RoadCareService.Interaction.Infrastructure.Persistence.EFC.Repositories;
using RoadCareService.Interaction.Domain.Repositories;
using RoadCareService.Interaction.Infrastructure.Socket;

using RoadCareService.Location.Application.Internal.QueryServices;
using RoadCareService.Location.Domain.Repositories;
using RoadCareService.Location.Domain.Services.Department;
using RoadCareService.Location.Domain.Services.District;
using RoadCareService.Location.Interfaces.ACL;
using RoadCareService.Location.Interfaces.ACL.Services;
using RoadCareService.Location.Infrastructure.Persistence.EFC.Repositories;

using RoadCareService.Monitoring.Application.Internal.CommandServices;
using RoadCareService.Monitoring.Application.Internal.QueryServices;
using RoadCareService.Monitoring.Domain.Repositories;
using RoadCareService.Monitoring.Domain.Services.DamagedInfrastructure;
using RoadCareService.Monitoring.Domain.Services.Staff;
using RoadCareService.Monitoring.Infrastructure.Persistence.EFC.Repositories;

using RoadCareService.Publishing.Application.Internal.CommandServices;
using RoadCareService.Publishing.Application.Internal.QueryServices;
using RoadCareService.Publishing.Domain.Repositories;
using RoadCareService.Publishing.Domain.Services.Evidence;
using RoadCareService.Publishing.Domain.Services.Publication;
using RoadCareService.Publishing.Interfaces.ACL;
using RoadCareService.Publishing.Interfaces.ACL.Services;
using RoadCareService.Publishing.Infrastructure.Persistence.EFC.Repositories;

using RoadCareService.Shared.Domain.Repositories;
using RoadCareService.Shared.Infrastructure.Persistence.EFC.Configuration;
using RoadCareService.Shared.Infrastructure.Persistence.EFC.Repositories;
using RoadCareService.Interaction.Domain.Services.Comment;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
        {
            Title = "RoadCareService",
            Version = "v1",
            Contact = new OpenApiContact
            {
                Name = "RoadCare",
                Email = "roadcare@hotmail.com"
            }
        });
    c.EnableAnnotations();
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
        {
            In = ParameterLocation.Header,
            Description = "Please enter token",
            Name = "Authorization",
            Type = SecuritySchemeType.Http,
            BearerFormat = "JWT",
            Scheme = "bearer"
        });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
        {
            {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Id = "Bearer", Type = ReferenceType.SecurityScheme
                    }
                },
                Array.Empty<string>()
            }
        });
});

builder.Services.AddHttpContextAccessor();

#region JWT Configuration

var jwtSettings = builder.Configuration.GetSection("JWT_SETTINGS");
builder.Services.Configure<JwtSettings>(jwtSettings);

var secretKey = jwtSettings["JWT_SECRET_KEY"];
var audience = jwtSettings["JWT_AUDIENCE_TOKEN"];
var issuer = jwtSettings["JWT_ISSUER_TOKEN"];
var securityKey = !string.IsNullOrEmpty(secretKey) ?
    new SymmetricSecurityKey
    (Encoding.Default.GetBytes(secretKey)) :
    throw new ArgumentNullException
    (nameof(secretKey), "Secret key is null or empty!");

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = issuer,
        ValidAudience = audience,
        IssuerSigningKey = securityKey,
        ClockSkew = TimeSpan.Zero
    };
});

builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddTransient<TokenValidationHandler>();

builder.Services.AddAuthorization();

#endregion

#region DataBase Configuration

builder.Services.AddTransient<IDbConnection>(db =>

    new SqlConnection(builder.Configuration
    .GetConnectionString("RoadCare"))
);
builder.Services.AddDbContext<RoadCareContext>(options =>
{
    options.UseSqlServer(builder.Configuration
        .GetConnectionString("RoadCare"));
});

#endregion

#region Dependencies Injections

#region Assignment Context

builder.Services.AddScoped<IAssignmentWorkerRepository, AssignmentWorkerRepository>();
builder.Services.AddScoped<IAssignmentWorkerCommandService, AssignmentWorkerCommandService>();
builder.Services.AddScoped<IAssignmentWorkerQueryService, AssignmentWorkerQueryService>();

builder.Services.AddScoped<IGovernmentEntityRepository, GovernmentEntityRepository>();
builder.Services.AddScoped<IGovernmentEntityQueryService, GovernmentEntityQueryService>();

builder.Services.AddScoped<IWorkerAreaRepository, WorkerAreaRepository>();
builder.Services.AddScoped<IWorkerAreaCommandService, WorkerAreaCommandService>();
builder.Services.AddScoped<IWorkerAreaQueryService, WorkerAreaQueryService>();

builder.Services.AddScoped<IWorkerRoleRepository, WorkerRoleRepository>();
builder.Services.AddScoped<IWorkerRoleCommandService, WorkerRoleCommandService>();
builder.Services.AddScoped<IWorkerRoleQueryService, WorkerRoleQueryService>();

builder.Services.AddTransient<RoadCareService.Assignment.Application.Internal.OutboundServices.ACL.ExternalIamService>();

#endregion

#region IAM Context

builder.Services.AddScoped<IWorkerRepository, WorkerRepository>();
builder.Services.AddScoped<IWorkerCommandService, WorkerCommandService>();
builder.Services.AddScoped<IWorkerQueryService, WorkerQueryService>();

builder.Services.AddScoped<ICitizenRepository, CitizenRepository>();
builder.Services.AddScoped<ICitizenCommandService, CitizenCommandService>();
builder.Services.AddScoped<ICitizenQueryService, CitizenQueryService>();

builder.Services.AddScoped<IWorkerCredentialRepository, WorkerCredentialRepository>();
builder.Services.AddScoped<IWorkerCredentialCommandService, WorkerCredentialCommandService>();
builder.Services.AddScoped<IWorkerCredentialQueryService, WorkerCredentialQueryService>();

builder.Services.AddScoped<ICitizenCredentialRepository, CitizenCredentialRepository>();
builder.Services.AddScoped<ICitizenCredentialCommandService, CitizenCredentialCommandService>();
builder.Services.AddScoped<ICitizenCredentialQueryService, CitizenCredentialQueryService>();

builder.Services.AddScoped<IEncryptionService, EncryptionService>();
builder.Services.AddScoped<IReniecService, ReniecService>();
builder.Services.AddScoped<IIamContextFacade, IamContextFacade>();

builder.Services.AddTransient<RoadCareService.IAM.Application.Internal.OutboundServices.ACL.ExternalLocationService>();

#endregion

#region Interaction Context

builder.Services.AddScoped<ICommentRepository, CommentRepository>();
builder.Services.AddScoped<ICommentCommandService, CommentCommandService>();
builder.Services.AddScoped<ICommentQueryService, CommentQueryService>();

builder.Services.AddTransient<RoadCareService.Interaction.Application.Internal.OutboundServices.ACL.ExternalIamService>();
builder.Services.AddTransient<RoadCareService.Interaction.Application.Internal.OutboundServices.ACL.ExternalPublishingService>();

#endregion

#region Location Context

builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();
builder.Services.AddScoped<IDepartmentQueryService, DepartmentQueryService>();

builder.Services.AddScoped<IDistrictRepository, DistrictRepository>();
builder.Services.AddScoped<IDistrictQueryService, DistrictQueryService>();

builder.Services.AddScoped<ILocationContextFacade, LocationContextFacade>();

#endregion

#region Monitoring Context

builder.Services.AddScoped<IDamagedInfrastructureRepository, DamagedInfrastructureRepository>();
builder.Services.AddScoped<IDamagedInfrastructureCommandService, DamagedInfrastructureCommandService>();
builder.Services.AddScoped<IDamagedInfrastructureQueryService, DamagedInfrastructureQueryService>();

builder.Services.AddScoped<IStaffRepository, StaffRepository>();
builder.Services.AddScoped<IStaffCommandService, StaffCommandService>();
builder.Services.AddScoped<IStaffQueryService, StaffQueryService>();

builder.Services.AddTransient<RoadCareService.Monitoring.Application.Internal.OutboundServices.ACL.ExternalIamService>();
builder.Services.AddTransient<RoadCareService.Monitoring.Application.Internal.OutboundServices.ACL.ExternalLocationService>();

#endregion

#region Publishing Context

builder.Services.AddScoped<IPublicationRepository, PublicationRepository>();
builder.Services.AddScoped<IPublicationCommandService, PublicationCommandService>();
builder.Services.AddScoped<IPublicationQueryService, PublicationQueryService>();

builder.Services.AddScoped<IEvidenceRepository, EvidenceRepository>();
builder.Services.AddScoped<IEvidenceCommandService, EvidenceCommandService>();
builder.Services.AddScoped<IEvidenceQueryService, EvidenceQueryService>();

builder.Services.AddScoped<IPublishingContextFacade, PublishingContextFacade>();

builder.Services.AddTransient<RoadCareService.Publishing.Application.Internal.OutboundServices.ACL.ExternalIamService>();
builder.Services.AddTransient<RoadCareService.Publishing.Application.Internal.OutboundServices.ACL.ExternalLocationService>();

#endregion

#region Shared Context

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

#endregion

#endregion

var app = builder.Build();

app.UseCors(
    c => c.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin()
);

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

#region WebSocket Configuration

var webSocketOptions = new WebSocketOptions()
{
    KeepAliveInterval = TimeSpan.FromMinutes(2),
};

app.UseWebSockets(webSocketOptions);

var webSocketHandler = new WebSocketHandler();

app.Map("/chat", webSocketHandler.HandleWebSocketAsync);

#endregion

app.UseRequestAuthorization();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();