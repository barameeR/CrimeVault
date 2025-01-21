using CrimeVault.Application;
using CrimeVault.Infrastructure;
using CrimeVault.Presentation;
using CrimeVault.WebAPI.Mapping;

namespace CrimeVault.WebAPI;

public static class WebAppInitializer
{
    public static void AddServices(this IServiceCollection services, ConfigurationManager configuration)
    {
        services.AddControllers();
        services.AddInfrastructure(configuration)
            .AddApplication()
            .AddPresentation()
            .AddMapping();
    }

    public static void InitializeWebApplication(this WebApplication app)
    {
        app.UseExceptionHandler("/error");
        app.UseHttpsRedirection();

        // Do not reorder these lines
        app.UseAuthentication();
        app.UseAuthorization();
        app.MapControllers();
        // Do not reorder these lines
        app.Run();
    }

    public static void Run(this WebApplicationBuilder builder)
    {
        builder.Services.AddServices(builder.Configuration);
        var app = builder.Build();
        app.InitializeWebApplication();
    }
}

