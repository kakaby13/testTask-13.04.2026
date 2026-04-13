using Microsoft.AspNetCore.Mvc;
using TestTask.BusinessLayer.Services;
using TestTask.DataLayer.DataModels;

namespace TestTask.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PatientController(IPatientService patientService) : ControllerBase
{
    [HttpPost]
    public async Task CreateAsync(Patient patient)
    {
        await patientService.CreateAsync(patient);
    }
    
    [HttpGet("{id:guid}")]
    public async Task<Patient?> GetById(Guid id)
    {
        return await patientService.GetByIdAsync(id);
    }
    
    [HttpGet]
    public async Task<List<Patient>> GetAllAsync()
    {
        return await patientService.GetAllAsync();
    }

    [HttpGet("by-birthdate")]
    public async Task<List<Patient>> GetAllByBirthDateAsync()
    {
        var parameters = Request.Query["BirthDate"].ToList();
        if (parameters.Count == 0)
        {
            throw  new ArgumentException("No birth date"); // todo
        }
        
        return await patientService.GetPatientsByDateParamsAsync(parameters!);
    } 
    
    [HttpPut("{id:guid}")]
    public async Task UpdateAsync(Guid id, [FromBody] Patient patient)
    {
        await patientService.UpdateAsync(id, patient);
    }

    [HttpDelete("{id:guid}")]
    public async Task DeleteAsync(Guid id)
    {
        await patientService.RemoveAsync(id);
    }
}