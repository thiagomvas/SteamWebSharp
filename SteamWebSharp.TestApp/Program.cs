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

var search = await client.ISteamMarket.SearchMarketAsync(440, "Mann Co. Supply Crate Key", 3, true);

foreach (var res in search.Results)
{
    Console.WriteLine(res.HashName);
}
