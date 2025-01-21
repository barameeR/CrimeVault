using CrimeVault.WebAPI;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddServices(builder.Configuration);
var app = builder.Build();
app.InitializeWebApplication();
