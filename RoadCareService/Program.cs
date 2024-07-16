using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using RoadCareService.IAM.Infrastructure.Token.JWT.Configuration;
using RoadCareService.IAM.Infrastructure.Token.JWT.Services;
using RoadCareService.Shared.Domain.Repositories;
using RoadCareService.Shared.Infrastructure.Persistence.EFC.Configuration;
using RoadCareService.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.Data.SqlClient;
using System.Data;
using RoadCareService.Publishing.Domain.Repositories;
using RoadCareService.Publishing.Infrastructure.Persistence.EFC.Repositories;
using RoadCareService.Publishing.Domain.Services.Department;
using RoadCareService.Publishing.Application.Internal.QueryServices;
using RoadCareService.Publishing.Infrastructure.Persistence.Dapper.Repositories;
using RoadCareService.Publishing.Domain.Services.District;
using RoadCareService.Publishing.Domain.Services.Publication;
using RoadCareService.Publishing.Application.Internal.CommandServices;
using RoadCareService.Publishing.Interfaces.ACL;
using RoadCareService.Publishing.Interfaces.ACL.Services;

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
builder.Services.AddTransient<TokenValidationHandlerService>();

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

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();
builder.Services.AddScoped<IDepartmentQueryService, DepartmentQueryService>();

builder.Services.AddScoped<IDistrictRepository, DistrictRepository>();
builder.Services.AddScoped<IDistrictQueryService, DistrictQueryService>();

builder.Services.AddScoped<IPublicationRepository, PublicationRepositoryDapper>();
builder.Services.AddScoped<IPublicationRepository, PublicationRepositoryEFC>();
builder.Services.AddScoped<IPublicationRepository, PublicationRepositoryEFC>();
builder.Services.AddScoped<IPublicationCommandService, PublicationCommandService>();
builder.Services.AddScoped<IPublicationQueryService, PublicationQueryService>();

builder.Services.AddScoped<IPublishingContextFacade, PublishingContextFacade>();

#endregion

var app = builder.Build();

app.UseCors(
    b => b.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin()
);

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();