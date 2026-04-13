using System.Globalization;
using Microsoft.AspNetCore.Mvc;
using TestTask.BusinessLayer.Dtos;
using TestTask.BusinessLayer.Services;

namespace TestTask.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PatientController(IPatientService patientService) : ControllerBase
{
    [HttpPost]
    public async Task CreateAsync([FromBody] PatientDto patient)
    {
        await patientService.CreateAsync(patient);
    }
    
    [HttpGet("{id:guid}")]
    public async Task<PatientDto?> GetById(Guid id)
    {
        return await patientService.GetByIdAsync(id);
    }
    
    [HttpGet]
    public async Task<List<PatientDto>> GetAllAsync()
    {
        return await patientService.GetAllAsync();
    }

    [HttpGet("by-birthdate")]
    public async Task<List<PatientDto>> GetAllByBirthDateAsync([FromQuery] string[] birthDateParameters)
    {
        var birthDates = Request.Query["birthDate"]
            .Select(v => v)
            .ToList();
        
        if (birthDates == null || birthDates.Count == 0)
        {
            throw  new ArgumentException("No birth date"); // todo
        }

        return await patientService.GetPatientsByDateParamsAsync(birthDates);
    } 
    
    [HttpPut("{id:guid}")]
    public async Task UpdateAsync(Guid id, [FromBody] PatientDto patient)
    {
        await patientService.UpdateAsync(id, patient);
    }

    [HttpDelete("{id:guid}")]
    public async Task DeleteAsync(Guid id)
    {
        await patientService.RemoveAsync(id);
    }
}