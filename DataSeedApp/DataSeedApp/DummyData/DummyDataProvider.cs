namespace DataSeedApp.DummyData;

public static class DummyDataProvider
{
    public static string[] FamilyNames =
    [
        "Smith", "Johnson", "Williams", "Brown", "Jones",
        "Garcia", "Miller", "Davis", "Rodriguez", "Martinez"
    ];

    public static string[] GivenNames =
        ["James", "Mary", "Robert", "Patricia", "John", "Jennifer", "Michael", "Linda", "William", "Elizabeth"];
    
    public static string[] Genders = ["Male, Female", "Other", "Unknown"];
    
    public static string[] BirthDates = 
    {
        "2013-01-14", "2013-01-14T10:00Z", "2013-01-14T10:00:00Z", 
        "2013-01-14T10:00:00+02:00", "2013-01-14T10:00:00.123+02:00",
        "2014-01-14", "2014-01-14T10:00Z", "2014-01-14T10:00:00Z", 
        "2014-01-14T10:00:00+02:00", "2014-01-14T10:00:00.123+02:00"
    };
}