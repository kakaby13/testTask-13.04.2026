using TestTask.BusinessLayer.Extensions;
using TestTask.DataLayer.Extensions;
using TestTask.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.ConfigureDataBase();
builder.Services
    .ConfigureFluentValidation()
    .AddMapsterMappingProfiles()
    .AddBusinessServices()
    .AddRepositories()
    .AddCorsConfiguration();

builder.Services.AddSwaggerGen();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddControllers();

var app = builder.Build();

app.AddCustomMiddlewares();

// Swagger allowed in production by technical requirements
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();
app.UseCors();

app.UseAuthorization();

app.MapControllers();

app.Run();