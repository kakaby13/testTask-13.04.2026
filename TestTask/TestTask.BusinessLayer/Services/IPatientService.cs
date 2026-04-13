using TestTask.DataLayer.DataModels;

namespace TestTask.BusinessLayer.Services;

public interface IPatientService
{
    Task CreateAsync(Patient patient);

    Task<Patient?> GetByIdAsync(Guid id);

    Task<List<Patient>> GetAllAsync();

    Task<List<Patient>> GetPatientsByDateParamsAsync(List<string> birthDateParameters);

    Task UpdateAsync(Patient patient);

    Task RemoveAsync(Patient patient);
}