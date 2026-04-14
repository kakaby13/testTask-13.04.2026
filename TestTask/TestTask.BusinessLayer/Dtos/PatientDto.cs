using System.ComponentModel.DataAnnotations;

namespace TestTask.BusinessLayer.Dtos;

public class PatientDto
{
    public NameDto Name { get; set; }
    
    public string Gender { get; set; }
    
    [Required]
    public DateTime BirthDate { get; set; }
    
    public string Active { get; set; }
}