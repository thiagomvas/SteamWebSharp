using Microsoft.Extensions.Logging;
using SteamWebSharp;

var apikey = File.ReadAllText("/home/thiagomv/.steamapikey").Replace("\n", "");
;
var builder = new SteamApiClientBuilder()
    .WithApiKey(apikey)
    .AddHttpClient(client => client.Timeout = TimeSpan.FromSeconds(30))
    .AddLogging(builder =>
    {
        builder.AddConsole().SetMinimumLevel(LogLevel.Trace);
    });
builder.Configuration.RetryAttempts = 3;
var client = builder.Build();
var summary = await client.ISteamUser.GetPlayerSummariesAsync(0);

Console.WriteLine(summary.PersonaName);