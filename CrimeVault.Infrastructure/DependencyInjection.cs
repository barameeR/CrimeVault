using CrimeVault.Application.Common.Interfaces.Persistence;
using CrimeVault.Infrastructure.Authentication;
using CrimeVault.Infrastructure.Persistence;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace CrimeVault.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, Microsoft.Extensions.Configuration.ConfigurationManager configuration)
    {
        services.AddAuth(configuration);
        services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
        services.AddScoped<IUserRepository, UserRepository>();
        return services;
    }

    public static IServiceCollection AddAuth(this IServiceCollection services, Microsoft.Extensions.Configuration.ConfigurationManager configuration)
    {
        var jwtSettings = new JwtSettings();
        configuration.GetSection(JwtSettings.SectionName).Bind(jwtSettings);
        //services.Configure<JwtSettings>(configuration.GetSection(JwtSettings.SectionName));
        // This change to vvv
        services.AddSingleton(Options.Create(jwtSettings));
        services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                       .AddJwtBearer(options =>
                       {
                           options.TokenValidationParameters = new TokenValidationParameters
                           {
                               // Validate the issuer (iss claim)
                               ValidateIssuer = true,
                               ValidIssuer = jwtSettings.Issuer,

                               // Validate the audience (aud claim)
                               ValidateAudience = true,
                               ValidAudience = jwtSettings.Audience, 

                               // Validate the signing key
                               ValidateIssuerSigningKey = true,
                               IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.Secret)),

                           };
                       });
        return services;
    }
}
