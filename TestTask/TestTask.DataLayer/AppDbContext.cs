using Microsoft.EntityFrameworkCore;
using TestTask.DataLayer.DataModels;

namespace TestTask.DataLayer;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Patient> Patients { get; set; }
}