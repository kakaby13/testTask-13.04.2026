using System.ComponentModel.DataAnnotations;

namespace TestTask.BusinessLayer.Dtos;

public class NameDto
{
    public Guid Id { get; set; }
    
    public string? Use { get; set; }
    
    [Required]
    public string Family { get; set; }
    
    public string[] Given { get; set; }
}