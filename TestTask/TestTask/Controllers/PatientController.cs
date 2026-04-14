using MapsterMapper;
using Microsoft.AspNetCore.Mvc;
using TestTask.BusinessLayer.Dtos;
using TestTask.BusinessLayer.QueryParameters;
using TestTask.BusinessLayer.Services;
using TestTask.Filters;

namespace TestTask.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PatientController(
    IPatientService patientService,
    IMapper mapper) 
    : ControllerBase
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
    public async Task<List<PatientDto>> GetAsync([FromQuery] PatientFilter filter)
    {
        var query = mapper.Map<PatientQuery>(filter);
        
        return await patientService.GetByQueryAsync(query);
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