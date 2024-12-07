using SteamWebSharp;

var client = new SteamApiClient("C19C127526046B5F8F9964330C5BEB9F");

var id = await client.ResolveVanityURLAsync("gaxyhs");
var result = await client.GetPlayerSummaryAsync(id);

Console.WriteLine(result);
