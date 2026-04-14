using System.Linq.Expressions;
using LinqKit;
using TestTask.BusinessLayer.Exceptions;
using TestTask.Core.FhirRangeParsers;
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

        if (!DateTime.TryParse(dateAsString, out _))
        {
            throw new UserFriendlyException($"DateTime format incorrect {dateAsString}");
        }

        var start = dateAsString.GetStartRange();
        var end = dateAsString.GetEndRange();
        
        return prefix switch
        {
            "eq" => p => p.BirthDate >= start && p.BirthDate <= end,
            "ne" => p => p.BirthDate < start || p.BirthDate > end,
            "gt" => p => p.BirthDate > end,
            "lt" => p => p.BirthDate < start,
            "ge" => p => p.BirthDate >= start,
            "le" => p => p.BirthDate <= end,
            "sa" => p => p.BirthDate > end,
            "eb" => p => p.BirthDate < start,
            "ap" => p => p.BirthDate >= start && p.BirthDate <= end,
            _ => p => p.BirthDate >= start && p.BirthDate <= end // todo update to real approximately 
        };
    }
}