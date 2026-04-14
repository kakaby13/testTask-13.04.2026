using Microsoft.Extensions.DependencyInjection;
using TestTask.DataLayer.Repositories;

namespace TestTask.DataLayer.Extensions;

public static class RepositoryExtensions
{
    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddTransient<PatientRepository>();
        
        return services;
    }
}