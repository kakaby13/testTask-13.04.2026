using System.ComponentModel.DataAnnotations;

namespace TestTask.BusinessLayer.Dtos;

public class PatientDto
{
    public Guid Id { get; set; }
    
    public string Use { get; set; }
    
    [Required]
    public string Family { get; set; }
    
    public string GivenName { get; set; }
    
    public string Surname { get; set; }
    
    public string Gender { get; set; }
    
    [Required]
    public DateTime BirthDate { get; set; }
    
    public string Active { get; set; }
}