using CrimeVault.Application;
using CrimeVault.Infrastructure;
using CrimeVault.Presentation;
using CrimeVault.WebAPI.Mapping;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services
    .AddApplication()
    .AddInfrastructure(builder.Configuration)
    .AddPresentation()
    .AddMapping();

var app = builder.Build();
app.UseExceptionHandler("/error");
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.UseAuthentication();
app.Run();
