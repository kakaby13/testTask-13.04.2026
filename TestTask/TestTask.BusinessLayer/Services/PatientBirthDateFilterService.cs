using System.Linq.Expressions;
using LinqKit;
using TestTask.DataLayer.DataModels;

namespace TestTask.BusinessLayer.Services;

public class PatientBirthDateFilterService : IPatientBirthDateFilterService
{
    private static readonly string[] Prefixes = ["eq", "ne", "gt", "lt", "ge", "le", "sa", "eb", "ap"];

    public Expression<Func<Patient, bool>> CreateFilterExpression(List<string> birthDateParameters)
    {
        return birthDateParameters
            .Select(CreateFilterExpression)
            .Aggregate<Expression<Func<Patient, bool>>?, Expression<Func<Patient, bool>>>(null!,
                (current, filter) => current.And(filter));
    }

    private static Expression<Func<Patient, bool>> CreateFilterExpression(string dateParameter)
    {
        var prefix = Prefixes.FirstOrDefault(p =>
            dateParameter.StartsWith(p, StringComparison.OrdinalIgnoreCase));

        if (prefix == null)
        {
            throw new ArgumentException($"text placeholder"); // todo
        }
        
        var dateString = dateParameter.Substring(prefix.Length);

        if (!DateTime.TryParse(dateString, out var date))
            throw new ArgumentException($"text placeholder'");  // todo
        
        return prefix switch
        {
            "eq" => p => p.BirthDate.Date == date.Date,
            "ne" => p => p.BirthDate.Date != date.Date,
            "gt" => p => p.BirthDate > date,
            "lt" => p => p.BirthDate < date,
            "ge" => p => p.BirthDate >= date,
            "le" => p => p.BirthDate <= date,
            _ => throw new ArgumentException($"text placeholder") // todo
        };
    }
}