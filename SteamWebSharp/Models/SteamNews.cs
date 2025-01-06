namespace SteamWebSharp.Models;

public class SteamNews
{
    public int AppId { get; set; }
    public List<NewsItem> NewsItems { get; set; }
}