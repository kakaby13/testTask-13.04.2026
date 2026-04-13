using System.Linq.Expressions;
using TestTask.DataLayer.DataModels;

namespace TestTask.BusinessLayer.Services;

public interface IPatientBirthDateFilterService
{
    public Expression<Func<Patient, bool>> CreateFilterExpression(List<string> birthDateParameters);
}