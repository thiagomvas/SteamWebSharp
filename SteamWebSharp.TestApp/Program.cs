using SteamWebSharp;

var client = new SteamApiClient("C19C127526046B5F8F9964330C5BEB9F");

var id = await client.ResolveVanityURLAsync("gaxyhs");
var result = await client.GetPlayerSummariesAsync([id, 76561198195352821]);

foreach (var r in result)
{
    Console.WriteLine(r);
}
