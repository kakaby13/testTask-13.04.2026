using Mapster;
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

    public async Task UpdateAsync(Guid id, Patient patient)
    {
        var existingEntity = await patientGenericRepository.GetByIdAsync(id);
        if (existingEntity == null)
        {
            throw new Exception($"text placeholder"); // todo
        }
        
        existingEntity.Adapt(patient);
        
        patientGenericRepository.Update(existingEntity);
        await context.SaveChangesAsync();
    }

    public async Task RemoveAsync(Guid id)
    {
        await patientGenericRepository.RemoveAsync(id);
        await context.SaveChangesAsync();
    }
}