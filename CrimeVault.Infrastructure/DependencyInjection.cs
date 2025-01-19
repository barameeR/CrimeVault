using CrimeVault.Application.Common.Interfaces.Persistence;
using CrimeVault.Infrastructure.Authentication;
using CrimeVault.Infrastructure.Persistence;
using Microsoft.Extensions.DependencyInjection;

namespace CrimeVault.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, Microsoft.Extensions.Configuration.ConfigurationManager configuration)
    {
        services.Configure<JwtSettings>(configuration.GetSection(JwtSettings.SectionName));
        services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
        services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
        services.AddScoped<IUserRepository, UserRepository>();
        return services;
    }
}