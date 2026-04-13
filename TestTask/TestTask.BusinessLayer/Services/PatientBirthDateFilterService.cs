using System.Linq.Expressions;
using LinqKit;
using TestTask.BusinessLayer.Exceptions;
using TestTask.DataLayer.DataModels;

namespace TestTask.BusinessLayer.Services;

public class PatientBirthDateFilterService : IPatientBirthDateFilterService
{
    private static readonly string[] Prefixes = ["eq", "ne", "gt", "lt", "ge", "le", "sa", "eb", "ap"];

    public Expression<Func<Patient, bool>> CreateFilterExpression(List<string> birthDateParameters)
    {
        var filter = PredicateBuilder.New<Patient>(true);

        foreach (var birthDate in birthDateParameters)
        {
            var newFilter = CreateFilterExpression(birthDate);
            filter = filter.And(newFilter);
        }

        return filter;
    }

    private static Expression<Func<Patient, bool>> CreateFilterExpression(string birthDateParameter)
    {
        var prefix = Prefixes.FirstOrDefault(p =>
            birthDateParameter.StartsWith(p, StringComparison.OrdinalIgnoreCase));

        if (prefix == null)
        {
            throw new UserFriendlyException("Datetime prefix incorrect");
        }
        
        var dateAsString = birthDateParameter.Substring(prefix.Length);

        if (!DateTime.TryParse(dateAsString, out var dateTime))
            throw new UserFriendlyException($"DateTime format incorrect {dateAsString}");
        
        return prefix switch
        {
            "eq" => p => p.BirthDate.Date == dateTime.Date,
            "ne" => p => p.BirthDate.Date != dateTime.Date,
            "lt" => p => p.BirthDate < dateTime,
            "gt" => p => p.BirthDate > dateTime,
            "ge" => p => p.BirthDate >= dateTime,
            "le" => p => p.BirthDate <= dateTime,
            _ => throw new UserFriendlyException(
                $"Datetime prefix:'{prefix}' not supported. sa, eb, ap not supported, rest - simplified")
        };
    }
}