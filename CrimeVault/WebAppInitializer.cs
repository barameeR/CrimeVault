using CrimeVault.Application;
using CrimeVault.Infrastructure;
using CrimeVault.Presentation;
using CrimeVault.WebAPI.Mapping;

namespace CrimeVault.WebAPI;

public static class WebAppInitializer
{
    public static void AddServices(IServiceCollection services, ConfigurationManager configuration)
    {
        services.AddControllers();
        services.AddInfrastructure(configuration)
            .AddApplication()
            .AddPresentation()
            .AddMapping();
    }

    public static void ConfigureMiddleware(WebApplication app)
    {
        app.UseExceptionHandler("/error");
        app.UseHttpsRedirection();

        // Do not reorder these lines
        app.UseAuthentication();
        app.UseAuthorization();
        app.MapControllers();
        // Do not reorder these lines
    }

    public static void InitializeWebApplication(WebApplication app)
    {
        ConfigureMiddleware(app);
        app.Run();
    }

    public static void Run(this WebApplicationBuilder builder)
    {
        AddServices(builder.Services, builder.Configuration);
        InitializeWebApplication(builder.Build());
    }
}
