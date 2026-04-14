using Mapster;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;
using TestTask.BusinessLayer.Dtos;
using TestTask.BusinessLayer.Exceptions;
using TestTask.BusinessLayer.QueryParameters;
using TestTask.DataLayer;
using TestTask.DataLayer.DataModels;
using TestTask.DataLayer.Repositories;

namespace TestTask.BusinessLayer.Services;

public class PatientService(
    IMapper mapper,
    PatientRepository patientRepository,
    IPatientBirthDateFilterService patientBirthDateFilterService,
    AppDbContext context)
    : IPatientService
{
    public async Task CreateAsync(PatientDto patientDto)
    {
        var patient = mapper.Map<Patient>(patientDto);
        
        await patientRepository.AddAsync(patient);
        await context.SaveChangesAsync();
    }

    public async Task<PatientDto?> GetByIdAsync(Guid id)
    {
        var patient = await patientRepository.FindByIdAsync(id);
        if (patient == null)
        {
            throw new UserFriendlyException($"Can't find entity by id: {id}");
        }
        
        return mapper.Map<PatientDto>(patient);
    }

    public async Task<List<PatientDto>> GetByQueryAsync(PatientQuery queryParams)
    {
        var query = patientRepository.Query();
        
        if (queryParams.BirthDates?.Any() == true)
        {
            var filter = patientBirthDateFilterService.CreateFilterExpression(queryParams.BirthDates);
            query = query.Where(filter);
        }

        if (!string.IsNullOrWhiteSpace(queryParams.Family))
        {
            query = query.Where(patient => patient.Family.Contains(queryParams.Family));
        }
        
        var patients = await query.ToListAsync();
        
        return mapper.Map<List<PatientDto>>(patients);
    }

    public async Task UpdateAsync(Guid id, PatientDto patientDto)
    {
        var existingEntity = await patientRepository.FindByIdAsync(id);
        if (existingEntity == null)
        {
            throw new UserFriendlyException($"Can't find entity by id: {id}");
        }
        
        var patient = mapper.Map<Patient>(patientDto);
        existingEntity.Adapt(patient);
        
        patientRepository.Update(existingEntity);
        await context.SaveChangesAsync();
    }

    public async Task RemoveAsync(Guid id)
    {
        await patientRepository.RemoveAsync(id);
        await context.SaveChangesAsync();
    }
}