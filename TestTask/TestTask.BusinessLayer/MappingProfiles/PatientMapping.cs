using TestTask.BusinessLayer.Dtos;
using TestTask.DataLayer.DataModels;
using TestTask.DataLayer.Enums;
using Mapster;

namespace TestTask.BusinessLayer.MappingProfiles;

public class PatientMapping : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<PatientDto, Patient>()
            .Map(dest => dest.Gender, src => Enum.Parse<Gender>(src.Gender, true))
            .Map(dest => dest.Active, src => Enum.Parse<Active>(src.Active, true));

        config.NewConfig<Patient, PatientDto>()
            .Map(dest => dest.Gender, src => src.Gender.ToString())
            .Map(dest => dest.Active, src => src.Active.ToString());
    }
}
