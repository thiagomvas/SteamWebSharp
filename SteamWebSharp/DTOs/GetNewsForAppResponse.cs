namespace SteamWebSharp.DTOs;

public class GetNewsForAppResponse
{
    public AppnewsDto appnews { get; set; }
}

public class AppnewsDto
{
    public int appid { get; set; }
    public NewsitemDto[] newsitems { get; set; }
    public int count { get; set; }
}

public class NewsitemDto
{
    public string gid { get; set; }
    public string title { get; set; }
    public string url { get; set; }
    public bool is_external_url { get; set; }
    public string author { get; set; }
    public string contents { get; set; }
    public string feedlabel { get; set; }
    public int date { get; set; }
    public string feedname { get; set; }
    public int feed_type { get; set; }
    public int appid { get; set; }
    public string[] tags { get; set; }
}