using TestTask.Core.FhirRangeParsers;

namespace TestTask.Core.Tests.DateTimeRangeParserTests;

public class GetEndRangeTests
{
    [Theory]
    [InlineData("2013-12-31T23:59:59.999Z", "2013")]
    [InlineData("2013-01-31T23:59:59.999Z", "2013-01")]
    [InlineData("2013-01-14T23:59:59.999Z", "2013-01-14")]
    [InlineData("2013-01-14T10:00:59.999Z", "2013-01-14T10:00Z")]
    [InlineData("2013-01-14T10:00:00.999Z", "2013-01-14T10:00:00Z")]
    [InlineData("2013-01-14T10:00:00.999+02:00", "2013-01-14T10:00:00+02:00")]
    [InlineData("2013-01-14T10:00:00.123+02:00", "2013-01-14T10:00:00.123+02:00")]
    public void GetEndRange_ParsesValidDate(string expected, string input)
    {
        var result = input.GetEndRange();

        Assert.Equal(DateTimeOffset.Parse(expected).UtcDateTime, result);
    }
}