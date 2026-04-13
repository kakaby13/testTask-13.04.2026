using Microsoft.Extensions.DependencyInjection;
using TestTask.BusinessLayer.Services;

namespace TestTask.BusinessLayer.Extensions;

public static class BusinessLayerExtensions
{
    public static IServiceCollection AddBusinessServices(this IServiceCollection services)
    {
        services.AddTransient<IPatientBirthDateFilterService, PatientBirthDateFilterService>();
        services.AddTransient<IPatientService, PatientService>();
        
        return services;
    }
}