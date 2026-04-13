using Microsoft.EntityFrameworkCore;
using TestTask.DataLayer;
using TestTask.DataLayer.DataModels;
using TestTask.DataLayer.Repositories;

namespace TestTask.BusinessLayer.Services;

public class PatientService(
    PatientGenericRepository patientGenericRepository,
    IPatientBirthDateFilterService patientBirthDateFilterService,
    AppDbContext context)
    : IPatientService
{
    public async Task CreateAsync(Patient patient)
    {
        await patientGenericRepository.AddAsync(patient);
        await context.SaveChangesAsync();
    }

    public async Task<Patient?> GetByIdAsync(Guid id)
    {
        return await patientGenericRepository.GetByIdAsync(id);
    }

    public async Task<List<Patient>> GetAllAsync()
    {
        return await patientGenericRepository.Query().ToListAsync();
    }
    
    public async Task<List<Patient>> GetPatientsByDateParamsAsync(List<string> birthDateParameters)
    {
        var filter = patientBirthDateFilterService.CreateFilterExpression(birthDateParameters);
        var query = patientGenericRepository.Query().Where(filter);

        return await query.ToListAsync();
    }

    public async Task UpdateAsync(Patient patient)
    {
        patientGenericRepository.Update(patient);
        await context.SaveChangesAsync();
    }

    public async Task RemoveAsync(Patient patient)
    {
        patientGenericRepository.Remove(patient);
        await context.SaveChangesAsync();
    }
}