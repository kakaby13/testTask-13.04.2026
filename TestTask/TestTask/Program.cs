using TestTask.BusinessLayer.Extensions;
using TestTask.DataLayer.Extensions;
using TestTask.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.ConfigureDataBase();
builder.Services
    .ConfigureFluentValidation()
    .AddMapsterConfig()
    .AddApiMapsterConfig()
    .AddBusinessServices()
    .AddRepositories()
    .AddCorsConfiguration();

builder.Services.AddSwaggerGen();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddControllers();

var app = builder.Build();

app
    .AddCustomMiddlewares()
    .ApplyMigrations() // Apply migration only for easy test setup, not for production us
    .AddSwagger(); // Swagger allowed in production by technical requirements

app.UseHttpsRedirection();
app.UseCors();
app.MapControllers();

app.Run();