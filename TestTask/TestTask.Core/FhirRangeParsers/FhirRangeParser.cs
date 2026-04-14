using Hl7.Fhir.Model;

namespace TestTask.Core.FhirRangeParsers;

public static class FhirRangeParser
{
    private static readonly TimeSpan DefaultOffset = DateTimeOffset.Now.Offset;

    public static DateTime GetStartRange(this string date)
    {
        if (string.IsNullOrWhiteSpace(date)) throw new ArgumentNullException(nameof(date));

        var fhirDateTime = new FhirDateTime(date);

        var dto = fhirDateTime.ToDateTimeOffset(DefaultOffset);
        
        return dto.UtcDateTime; 
    }
    
    public static DateTime GetEndRange(this string date)
    {
        if (string.IsNullOrEmpty(date)) throw new ArgumentNullException(nameof(date));

        var fhirDateTime = new FhirDateTime(date);
        var start = fhirDateTime.ToDateTimeOffset(DefaultOffset).UtcDateTime;

        var hasTime = date.Contains('T');
        var hasSeconds = hasTime && System.Text.RegularExpressions.Regex.IsMatch(date, @"T\d{2}:\d{2}:\d{2}");
        var hasMilliseconds = date.Contains('.');

        if (hasMilliseconds) 
            return start;

        if (hasSeconds)
            return start.AddSeconds(1).AddMilliseconds(-1);

        if (hasTime)
            return start.AddMinutes(1).AddMilliseconds(-1);

        return date.Length switch
        {
            4 => start.AddYears(1).AddMilliseconds(-1),
            7 => start.AddMonths(1).AddMilliseconds(-1),
            10 => start.AddDays(1).AddMilliseconds(-1),
            _ => start
        };
    }
}