using TestTask.BusinessLayer.Extensions;
using TestTask.DataLayer.Extensions;
using TestTask.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Configure DB
builder.ConfigureDataBase();

// Add DI configuration
builder.Services
    .AddMapsterMappingProfiles()
    .AddBusinessServices()
    .AddRepositories();

builder.Services.AddSwaggerGen();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddControllers();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy
            .AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors();

app.UseAuthorization();

app.MapControllers();

app.Run();