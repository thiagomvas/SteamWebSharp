using Microsoft.Extensions.Logging;
using SteamWebSharp;
using SteamWebSharp.Models.Market;

var apikey = File.ReadAllText("/home/thiagomv/.steamapikey").Replace("\n", "");

var builder = new SteamApiClientBuilder()
    .WithApiKey(apikey)
    .AddHttpClient(client => client.Timeout = TimeSpan.FromSeconds(30))
    .AddLogging(builder =>
    {
        builder.AddConsole().SetMinimumLevel(LogLevel.Trace);
    });
var client = builder.Build();

var result = await client.ISteamUserStats.GetSchemaForGameAsync(881100);

// log as json
Console.WriteLine(System.Text.Json.JsonSerializer.Serialize(result, new System.Text.Json.JsonSerializerOptions { WriteIndented = true }));
