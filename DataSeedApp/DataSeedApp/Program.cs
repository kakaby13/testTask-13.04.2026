using DataSeedApp;
using DataSeedApp.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();

var configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appSettings.json")
    .Build();

var app = services
    .AddSingleton<IConfiguration>(configuration)
    .ConfigureServices()
    .AddHttpClient()
    .BuildServiceProvider()
    .GetRequiredService<DataSeedService>();

await app.Run();