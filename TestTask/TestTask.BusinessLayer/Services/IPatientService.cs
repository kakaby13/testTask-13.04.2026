using TestTask.BusinessLayer.Dtos;
using TestTask.DataLayer.DataModels;

namespace TestTask.BusinessLayer.Services;

public interface IPatientService
{
    Task CreateAsync(PatientDto patient);

    Task<PatientDto?> GetByIdAsync(Guid id);

    Task<List<PatientDto>> GetAllAsync();

    Task<List<PatientDto>> GetPatientsByDateParamsAsync(List<string> birthDateParameters);

    Task UpdateAsync(Guid id, PatientDto patient);

    Task RemoveAsync(Guid id);
}