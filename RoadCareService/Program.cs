using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Data;
using System.Text;
using RoadCareService.IAM.Infrastructure.Token.JWT.Configuration;
using RoadCareService.IAM.Infrastructure.Token.JWT.Services;
using RoadCareService.Shared.Domain.Repositories;
using RoadCareService.Shared.Infrastructure.Persistence.EFC.Configuration;
using RoadCareService.Shared.Infrastructure.Persistence.EFC.Repositories;
using RoadCareService.Publishing.Domain.Repositories;
using RoadCareService.Publishing.Infrastructure.Persistence.EFC.Repositories;
using RoadCareService.Publishing.Domain.Services.Department;
using RoadCareService.Publishing.Application.Internal.QueryServices;
using RoadCareService.Publishing.Domain.Services.District;
using RoadCareService.Publishing.Domain.Services.Publication;
using RoadCareService.Publishing.Application.Internal.CommandServices;
using RoadCareService.Publishing.Interfaces.ACL;
using RoadCareService.Publishing.Interfaces.ACL.Services;
using RoadCareService.Interaction.Infrastructure.Socket;
using RoadCareService.Interaction.Domain.Repositories;
using RoadCareService.Interaction.Infrastructure.Persistence.EFC.Repositories;
using RoadCareService.Interaction.Domain.Services;
using RoadCareService.Interaction.Application.Internal.CommandServices;
using RoadCareService.Interaction.Application.Internal.QueryServices;
using RoadCareService.Interaction.Application.Internal.OutboundServices.ACL;
using RoadCareService.Publishing.Domain.Services.Evidence;
using RoadCareService.Monitoring.Domain.Repositories;
using RoadCareService.Monitoring.Infrastructure.Persistence.EFC.Repositories;
using RoadCareService.Monitoring.Domain.Services.DamagedInfrastructure;
using RoadCareService.Monitoring.Application.Internal.CommandServices;
using RoadCareService.Monitoring.Application.Internal.QueryServices;
using RoadCareService.Monitoring.Domain.Services.Staff;
using RoadCareService.Assignment.Domain.Repositories;
using RoadCareService.Assignment.Infrastructure.Persistence.EFC.Repositories;
using RoadCareService.Assignment.Domain.Services.AssignmentWorker;
using RoadCareService.Assignment.Application.Internal.CommandServices;
using RoadCareService.Assignment.Application.Internal.QueryServices;
using RoadCareService.Assignment.Domain.Services.GovernmentEntity;
using RoadCareService.Assignment.Domain.Services.WorkerArea;
using RoadCareService.Assignment.Domain.Services.WorkerRole;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
        {
            Title = "RoadCareService",
            Version = "v1",
            TermsOfService = new Uri("https://acme-learning.com/tos"),
            Contact = new OpenApiContact
            {
                Name = "RoadCare",
                Email = "roadcare@hotmail.com"
            },
            License = new OpenApiLicense
            {
                Name = "Apache 2.0",
                Url = new Uri("https://www.apache.org/licenses/LICENSE-2.0.html")
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

#region JWT Configuration

var jwtSettings = builder.Configuration.GetSection("JWT_SETTINGS");
builder.Services.Configure<JwtSettings>(jwtSettings);

var secretKey = jwtSettings["JWT_SECRET_KEY"];
var audience = jwtSettings["JWT_AUDIENCE_TOKEN"];
var issuer = jwtSettings["JWT_ISSUER_TOKEN"];
var expireMinutes = int.Parse(jwtSettings["JWT_EXPIRE_MINUTES"]);
var securityKey = new SymmetricSecurityKey(Encoding.Default.GetBytes(jwtSettings["JWT_SECRET_KEY"]));

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

builder.Services.AddTransient<TokenGeneratorService>();
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

#region Shared Context

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

#endregion

#region Publishing Context

builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();
builder.Services.AddScoped<IDepartmentQueryService, DepartmentQueryService>();

builder.Services.AddScoped<IDistrictRepository, DistrictRepository>();
builder.Services.AddScoped<IDistrictQueryService, DistrictQueryService>();

builder.Services.AddScoped<IPublicationRepository, PublicationRepository>();
builder.Services.AddScoped<IPublicationCommandService, PublicationCommandService>();
builder.Services.AddScoped<IPublicationQueryService, PublicationQueryService>();

builder.Services.AddScoped<IPublishingContextFacade, PublishingContextFacade>();

builder.Services.AddScoped<IEvidenceRepository, EvidenceRepository>();
builder.Services.AddScoped<IEvidenceCommandService, EvidenceCommandService>();
builder.Services.AddScoped<IEvidenceQueryService, EvidenceQueryService>();

#endregion

#region Interaction Context

builder.Services.AddScoped<ICommentRepository, CommentRepository>();
builder.Services.AddScoped<ICommentCommandService, CommentCommandService>();
builder.Services.AddScoped<ICommentQueryService, CommentQueryService>();

builder.Services.AddTransient<ExternalPublishingService>();

#endregion

#region Monitoring Context

builder.Services.AddScoped<IDamagedInfrastructureRepository, DamagedInfrastructureRepository>();
builder.Services.AddScoped<IDamagedInfrastructureCommandService, DamagedInfrastructureCommandService>();
builder.Services.AddScoped<IDamagedInfrastructureQueryService, DamagedInfrastructureQueryService>();

builder.Services.AddScoped<IStaffRepository, StaffRepository>();
builder.Services.AddScoped<IStaffCommandService, StaffCommandService>();
builder.Services.AddScoped<IStaffQueryService, StaffQueryService>();

#endregion

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

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();