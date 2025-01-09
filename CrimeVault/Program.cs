var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services
    .AddApplication()
    .AddInfrastructure()
    .AddPresentation();

var app = builder.Build();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
