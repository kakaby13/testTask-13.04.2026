using System.Net.Http.Json;
using DataSeedApp.DummyData;
using Microsoft.Extensions.Configuration;

namespace DataSeedApp;

using System.Net.Http;

public class DataSeedService(IHttpClientFactory httpClientFactory, IConfiguration configuration)
{
    public async Task Run()
    {
        var client = httpClientFactory.CreateClient();

        var range = Enumerable.Range(0, 100);
        var options = new ParallelOptions 
        { 
            MaxDegreeOfParallelism = 10
        };

        await Parallel.ForEachAsync(range, options, async (i, token) =>
        {
            try
            {
                var payload = GetPayload();
                var response = await client.PostAsJsonAsync(configuration["PatientApi:BaseUrl"], payload, token);
                Console.WriteLine($"Request {i}: {response.StatusCode}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error code {i}: {ex.Message}");
            }
        });
    }

    private object GetPayload()
    {
        var family = DummyDataProvider.FamilyNames[Random.Shared.Next(DummyDataProvider.FamilyNames.Length)];
        
        var firstName = Random.Shared.Next(0, 3) == 0 
            ? null 
            : DummyDataProvider.GivenNames[Random.Shared.Next(DummyDataProvider.GivenNames.Length)];

        var givenList = new List<string> { family };
        if (firstName != null)
        {
            givenList.Add(firstName);
        }
        
        var payload = new
        {
            name = new
            {
                use = "test",
                family = family,
                given = givenList.ToArray()
            },
            gender = DummyDataProvider.Genders[Random.Shared.Next(DummyDataProvider.Genders.Length)],
            birthDate = DummyDataProvider.BirthDates[Random.Shared.Next(DummyDataProvider.BirthDates.Length)],
            active = true
        };

        return payload;
    }
}