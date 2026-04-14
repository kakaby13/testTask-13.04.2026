using TestTask.BusinessLayer.Dtos;
using TestTask.BusinessLayer.QueryParameters;

namespace TestTask.BusinessLayer.Services;

public interface IPatientService
{
    Task CreateAsync(PatientDto patient);

    Task<PatientDto?> GetByIdAsync(Guid id);
    
    Task<List<PatientDto>> GetByQueryAsync(PatientQuery queryParams);
    
    Task UpdateAsync(Guid id, PatientDto patient);

    Task RemoveAsync(Guid id);
}