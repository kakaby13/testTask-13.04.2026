using Mapster;
using TestTask.BusinessLayer.QueryParameters;
using TestTask.Filters;

namespace TestTask.MappingProfiles;

public class PatientFilterMapping : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<PatientFilter, PatientQuery>();

        config.NewConfig<PatientQuery, PatientFilter>();
    }
}
