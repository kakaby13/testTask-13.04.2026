using Mapster;
using MapsterMapper;
using TestTask.MappingProfiles;

namespace TestTask.Extensions;

public static class ConfigureMappingExtensions
{
    public static IServiceCollection AddApiMapsterConfig(this IServiceCollection services)
    {
        var config = TypeAdapterConfig.GlobalSettings;

        config.Scan(typeof(PatientFilterMapping).Assembly);

        services.AddSingleton(config);
        services.AddScoped<IMapper, ServiceMapper>();

        return services;
    }
}