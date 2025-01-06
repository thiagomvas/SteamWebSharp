using SteamWebSharp.DTOs;
using SteamWebSharp.Interfaces;
using SteamWebSharp.Models;

namespace SteamWebSharp;

public class SteamNewsEndpoints : ISteamNews
{
    private readonly SteamApiClient _client;

    public SteamNewsEndpoints(SteamApiClient client)
    {
        _client = client;
    }
    public async Task<SteamNews> GetNewsForAppAsync(uint appId, uint count = 0, uint maxLength = 0, uint endDate = 0)
    {
        var url = $"/ISteamNews/GetNewsForApp/v2/?appid={appId}";
        if(count > 0)
            url += $"&count={count}";
        
        if(maxLength > 0)
            url += $"&maxlength={maxLength}";
        
        if(endDate > 0)
            url += $"&enddate={endDate}";
        
        var response = await _client.GetAsync<GetNewsForAppResponse>(url);

        var result = new SteamNews()
        {
            AppId = response.appnews.appid,
            NewsItems = response.appnews.newsitems.Select(ni =>
            {
                return new NewsItem()
                {
                    Gid = ulong.Parse(ni.gid),
                    Title = ni.title,
                    Url = ni.url,
                    IsExternalUrl = ni.is_external_url,
                    Author = ni.author,
                    Contents = ni.contents,
                    FeedLabel = ni.feedlabel,
                    Date = DateTimeOffset.FromUnixTimeSeconds(ni.date).DateTime,
                    FeedName = ni.feedname,
                    FeedType = ni.feed_type,
                };
            }).ToList()
        };

        return result;
    }
}