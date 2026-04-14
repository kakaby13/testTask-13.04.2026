using TestTask.Core.FhirRangeParsers;

namespace TestTask.Core.Tests.DateTimeRangeParserTests;

public class GetStartRangeTests
{
    [Theory]
    [InlineData("2013-01-01T00:00:00.000Z", "2013")]
    [InlineData("2013-01-01T00:00:00.000Z", "2013-01")]
    [InlineData("2013-01-14T00:00:00.000Z", "2013-01-14")]
    [InlineData("2013-01-14T10:00:00.000Z", "2013-01-14T10:00Z")]
    [InlineData("2013-01-14T10:00:00.000Z", "2013-01-14T10:00:00Z")]
    [InlineData("2013-01-14T10:00:00.000+02:00", "2013-01-14T10:00:00+02:00")]
    [InlineData("2013-01-14T10:00:00.123+02:00", "2013-01-14T10:00:00.123+02:00")]
    [InlineData("2013-01-14T10:00:00.123-02:00", "2013-01-14T10:00:00.123-02:00")]
    public void GetStartRange_ParsesValidDate(string expected, string input)
    {
        var result = input.GetStartRange();
        
        Assert.Equal(DateTimeOffset.Parse(expected).UtcDateTime, result);
    }
}