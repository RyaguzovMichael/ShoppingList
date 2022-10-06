using Authorization.API.Mappings;
using Authorization.Application.Mappings;
using AutoMapper;
using CommonRepository.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Authorization.API;

public static class DependencyInjection
{
    public static IServiceCollection SetJwtTokenServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<JWTSettings>(configuration.GetSection("JWTSettings"));

        var secretKey = configuration.GetSection("JWTSettings:SecretKey").Value;
        var issuer = configuration.GetSection("JWTSettings:Issuer").Value;
        var audience = configuration.GetSection("JWTSettings:Audience").Value;
        var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));

        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
        })
        .AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidIssuer = issuer,
                ValidateAudience = true,
                ValidAudience = audience,
                ValidateLifetime = true,
                IssuerSigningKey = signingKey,
                ValidateIssuerSigningKey = true
            };
        });
        return services;
    }

    public static IServiceCollection SetAutomapperProfiles(this IServiceCollection services)
    {
        services.AddSingleton(provider => new MapperConfiguration(cfg =>
        {
            cfg.AddProfile(new FrontendMappingProfile());
            cfg.AddProfile(new BackendMappingProfile());
        }).CreateMapper());
        return services;
    }
}
