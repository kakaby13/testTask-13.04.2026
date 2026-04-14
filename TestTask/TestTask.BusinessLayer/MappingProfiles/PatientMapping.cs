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
            .Map(dest => dest.Id, src => src.Name.Id)
            .Map(dest => dest.Use, src => src.Name.Use)
            .Map(dest => dest.Family, src => src.Name.Family)
            .Map(dest => dest.GivenName, src => src.Name.Given != null && src.Name.Given.Length > 1 
                ? src.Name.Given[1] 
                : null)
            .Map(dest => dest.Surname, src => src.Name.Given != null && src.Name.Given.Length > 2 
                ? src.Name.Given[2] 
                : null)
            .Map(dest => dest.Gender, src => Enum.Parse<Gender>(src.Gender))
            .Map(dest => dest.Active, src => Enum.Parse<Active>(src.Active));

        config.NewConfig<Patient, PatientDto>()
            .Map(dest => dest.Name, src => new NameDto
            {
                Id = src.Id,
                Use = src.Use,
                Family = src.Family,
                Given = new[] { src.Family, src.GivenName, src.Surname }
            })
            .Map(dest => dest.Gender, src => src.Gender.ToString())
            .Map(dest => dest.Active, src => src.Active.ToString());
    }
}
