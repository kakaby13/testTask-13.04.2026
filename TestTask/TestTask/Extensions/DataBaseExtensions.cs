using Microsoft.EntityFrameworkCore;
using TestTask.DataLayer;

namespace TestTask.Extensions;

public static class DataBaseExtensions
{
    public static WebApplicationBuilder ConfigureDataBase(this WebApplicationBuilder builder)
    {
        var connectionString = Environment.GetEnvironmentVariable("TEST_CONNECTION_STRING_13042026");

        builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));
        
        return builder;
    }
}