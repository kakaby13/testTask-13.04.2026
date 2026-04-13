using Mapster;
using MapsterMapper;
using Microsoft.Extensions.DependencyInjection;
using TestTask.BusinessLayer.MappingProfiles;
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

    public static IServiceCollection AddMapsterMappingProfiles(this IServiceCollection services)
    {
        var config = TypeAdapterConfig.GlobalSettings;

        config.Scan(typeof(PatientMapping).Assembly);

        services.AddSingleton(config);
        services.AddScoped<IMapper, ServiceMapper>();

        return services;
    }
}