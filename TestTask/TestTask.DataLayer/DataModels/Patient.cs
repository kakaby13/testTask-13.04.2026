using TestTask.DataLayer.Enums;

namespace TestTask.DataLayer.DataModels;

public class Patient
{
    public Guid Id { get; set; }
    
    public string Use { get; set; }
    
    public string Family { get; set; }
    
    public string GivenName { get; set; }
    
    public string Surname { get; set; }
    
    public Gender Gender { get; set; }
    
    public DateTime BirthDate { get; set; }
    
    public Active Active { get; set; }
}