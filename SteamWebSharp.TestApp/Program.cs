using SteamWebSharp;

var apikey = File.ReadAllText("/home/thiagomv/.steamapikey").Replace("\n", "");;

var client = new SteamApiClient(apikey);

var news = await client.ISteamNews.GetNewsForAppAsync(440);

foreach(var item in news.NewsItems)
{
    Console.WriteLine(item.Title);
    Console.WriteLine(item.Url);
    Console.WriteLine(item.Author);
    Console.WriteLine(item.Contents);
    Console.WriteLine();
}