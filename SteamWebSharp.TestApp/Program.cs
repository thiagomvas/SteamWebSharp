using Microsoft.Extensions.Logging;
using SteamWebSharp;

var apikey = File.ReadAllText("/home/thiagomv/.steamapikey").Replace("\n", "");
;
var client = new SteamApiClientBuilder()
    .WithApiKey(apikey)
    .AddHttpClient(client => client.Timeout = TimeSpan.FromSeconds(30))
    .AddLogging(builder => builder.AddConsole())
    .Build();
