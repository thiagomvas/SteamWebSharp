namespace SteamWebSharp.Interfaces;

public interface ISteamNews
{
    /// <summary>
    /// Gets the news for a specific app.
    /// </summary>
    /// <param name="appId">The AppID to retrieve news for</param>
    /// <param name="count">Number of posts to retrieve (default 20)</param>
    /// <param name="maxLength">Maximum length for the content to return, if this is 0 the full content is returned, if it's less then a blurb is generated to fit.</param>
    /// <param name="endDate">Retrieve posts earlier than this date (unix epoch timestamp)</param>
    /// <returns>The news for the app with the specified <paramref name="appId"/></returns>
    Task<SteamNews> GetNewsForAppAsync(uint appId, uint count = 20, uint maxLength = 0, uint endDate = 0);
}