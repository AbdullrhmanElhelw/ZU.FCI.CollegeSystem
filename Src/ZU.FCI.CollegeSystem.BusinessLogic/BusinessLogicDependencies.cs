using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Reflection;
using System.Text;
using ZU.FCI.CollegeSystem.BusinessLogic.Contracts.Authentication.Jwt;
using ZU.FCI.CollegeSystem.BusinessLogic.Contracts.Authentication.Settings;
using ZU.FCI.CollegeSystem.BusinessLogic.Contracts.CQRS.Behaviors;
using ZU.FCI.CollegeSystem.BusinessLogic.Contracts.Utilities;
using ZU.FCI.CollegeSystem.DataAccess.Common;
using ZU.FCI.CollegeSystem.DataAccess.Data;
using ZU.FCI.CollegeSystem.DataAccess.Entites.Identity.Doctors;
using ZU.FCI.CollegeSystem.DataAccess.Entites.Identity.Students;
using ZU.FCI.CollegeSystem.DataAccess.Enums;

namespace ZU.FCI.CollegeSystem.BusinessLogic;

public static class BusinessLogicDependencies
{
    public static IServiceCollection AddBusinessLogic(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<JwtSettings>(configuration.GetSection(JwtSettings.SettingsKey));
        services.AddScoped<IJwtProvider, JwtProvider>();

        services.AddMediatR(c => c.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationPipelineBehavior<,>));
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

        services.AddScoped<UserUtility>();

        return services;
    }

    public static IServiceCollection AddIdentityUsers(this IServiceCollection services)
    {
        services.AddIdentity<ApplicationUser, IdentityRole<int>>(options =>
        {
            options.Password.RequireDigit = true;
            options.Password.RequireLowercase = true;
            options.Password.RequireUppercase = true;
            options.Password.RequireNonAlphanumeric = true;
            options.Password.RequiredLength = 8;
            options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
            options.Lockout.MaxFailedAccessAttempts = 5;
            options.Lockout.AllowedForNewUsers = true;
        })
            .AddEntityFrameworkStores<CollegeSystemDbContext>()
            .AddRoles<IdentityRole<int>>()
            .AddDefaultTokenProviders();

        services.AddIdentityCore<Student>()
            .AddRoles<IdentityRole<int>>()
            .AddEntityFrameworkStores<CollegeSystemDbContext>()
            .AddDefaultTokenProviders();

        services.AddIdentityCore<Doctor>()
         .AddRoles<IdentityRole<int>>()
         .AddEntityFrameworkStores<CollegeSystemDbContext>()
         .AddDefaultTokenProviders();

        return services;
    }

    public static IServiceCollection AddAuthenticationSchema(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddAuthentication(op =>
        {
            op.DefaultAuthenticateScheme = "Default";
            op.DefaultChallengeScheme = "Default";
        })
            .AddJwtBearer("Default", op =>
            {
                var settings = configuration.GetSection(JwtSettings.SettingsKey).Get<JwtSettings>();
                var readKey = Encoding.ASCII.GetBytes(settings.Key);
                var key = new SymmetricSecurityKey(readKey);
                op.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = false,
                    ValidateIssuerSigningKey = false,
                    ValidIssuer = settings.Issuer,
                    ValidAudience = settings.Audience,
                    IssuerSigningKey = key
                };
            });

        return services;
    }

    public static IServiceCollection AddAuthorizationPolices(this IServiceCollection services)
    {
        services.AddAuthorizationBuilder()
            .AddPolicy(nameof(ApplicationRoles.Admin), policy => policy.RequireRole(nameof(ApplicationRoles.Admin)))
            .AddPolicy(nameof(ApplicationRoles.Student), policy => policy.RequireRole(nameof(ApplicationRoles.Student)))
            .AddPolicy(nameof(ApplicationRoles.Doctor), policy => policy.RequireRole(nameof(ApplicationRoles.Doctor)))
            .AddPolicy(nameof(ApplicationRoles.Assistant), policy => policy.RequireRole(nameof(ApplicationRoles.Assistant)))
            .AddPolicy(nameof(ApplicationRoles.Parent), policy => policy.RequireRole(nameof(ApplicationRoles.Parent)));

        return services;
    }
}