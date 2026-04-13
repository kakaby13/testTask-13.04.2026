using TestTask.DataLayer.DataModels;

namespace TestTask.DataLayer.Repositories;

public class PatientGenericRepository(AppDbContext context) : GenericRepository<Patient>(context)
{

}