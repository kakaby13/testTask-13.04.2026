using Mapster;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;
using TestTask.BusinessLayer.Dtos;
using TestTask.DataLayer;
using TestTask.DataLayer.DataModels;
using TestTask.DataLayer.Repositories;

namespace TestTask.BusinessLayer.Services;

public class PatientService(
    IMapper mapper,
    PatientGenericRepository patientGenericRepository,
    IPatientBirthDateFilterService patientBirthDateFilterService,
    AppDbContext context)
    : IPatientService
{
    public async Task CreateAsync(PatientDto patientDto)
    {
        var patient = mapper.Map<Patient>(patientDto);
        
        await patientGenericRepository.AddAsync(patient);
        await context.SaveChangesAsync();
    }

    public async Task<PatientDto?> GetByIdAsync(Guid id)
    {
        var patient = await patientGenericRepository.FindByIdAsync(id);
        
        return mapper.Map<PatientDto>(patient); // todo
    }

    public async Task<List<PatientDto>> GetAllAsync()
    {
        var patients = await patientGenericRepository.Query().ToListAsync();
        
        return mapper.Map<List<PatientDto>>(patients);
    }
    
    public async Task<List<PatientDto>> GetPatientsByDateParamsAsync(List<string> birthDateParameters)
    {
        var filter = patientBirthDateFilterService.CreateFilterExpression(birthDateParameters);
        var query = patientGenericRepository.Query().Where(filter);

        var patients = await query.ToListAsync();
        
        return mapper.Map<List<PatientDto>>(patients);
    }

    public async Task UpdateAsync(Guid id, PatientDto patientDto)
    {
        var existingEntity = await patientGenericRepository.FindByIdAsync(id);
        if (existingEntity == null)
        {
            throw new Exception($"text placeholder"); // todo
        }
        var patient = mapper.Map<Patient>(patientDto);
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