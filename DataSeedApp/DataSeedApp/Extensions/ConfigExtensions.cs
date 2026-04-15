using Microsoft.Extensions.DependencyInjection;

namespace DataSeedApp.Extensions;

public static class ConfigExtensions
{
    public static IServiceCollection ConfigureServices(this IServiceCollection services)
    {
        services.AddTransient<DataSeedService>();
        
        return services;
    }
}