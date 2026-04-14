using TestTask.DataLayer.DataModels;

namespace TestTask.DataLayer.Repositories;

public class PatientRepository(AppDbContext context) : GenericRepository<Patient>(context)
{

}