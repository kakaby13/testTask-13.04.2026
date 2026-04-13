using TestTask.DataLayer.Extensions;
using TestTask.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Configure DB
builder.ConfigureDataBase();

// Add DI configuration
builder.Services.AddRepositories();

builder.Services.AddControllers();

builder.Services.AddOpenApi();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();