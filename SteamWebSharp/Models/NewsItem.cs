namespace SteamWebSharp;

public class NewsItem
{
    public ulong Gid { get; set; }
    public string Title { get; set; }
    public string Url { get; set; }
    public bool IsExternalUrl { get; set; }
    public string Author { get; set; }
    public string Contents { get; set; }
    public string FeedLabel { get; set; }
    public DateTime Date { get; set; }
    public string FeedName { get; set; }
    public int FeedType { get; set; }
    public int Appid { get; set; }
}