using SteamWebSharp.DTOs;
using SteamWebSharp.Interfaces;
using SteamWebSharp.Models;

namespace SteamWebSharp;

public class PlayerServiceEndpoints : IPlayerService
{
    private readonly SteamApiClient _client;
    
    public PlayerServiceEndpoints(SteamApiClient client)
    {
        _client = client;
    }
    public async Task<IEnumerable<OwnedGame>> GetOwnedGamesAsync(ulong steamId, bool includeAppInfo = true, bool includePlayedFreeGames = false,
        bool includeFreeSub = false, bool includeExtendedAppInfo = false)
    {
        var url = $"IPlayerService/GetOwnedGames/v1/?steamid={steamId}&include_appinfo={includeAppInfo}&include_played_free_games={includePlayedFreeGames}&include_free_sub={includeFreeSub}&include_extended_info={includeExtendedAppInfo}";
        return await _client.GetAsync<IEnumerable<OwnedGame>>(url, "response/games");
        var response = await _client.GetAsync<GetOwnedGamesResponse>(url);
        
        return response.games.Select(game => new OwnedGame
        {
            AppId = game.appid,
            Name = game.name,
            PlaytimeForever = game.playtime_forever,
            ImgIconUrl = game.img_icon_url,
            PlaytimeWindowsForever = game.playtime_windows_forever,
            PlaytimeMacForever = game.playtime_mac_forever,
            PlaytimeLinuxForever = game.playtime_linux_forever,
            PlaytimeDeckForever = game.playtime_deck_forever,
            LastPlayed = DateTimeOffset.FromUnixTimeSeconds(game.rtime_last_played).DateTime,
            CapsuleFileName = game.capsule_filename,
            HasWorkshop = game.has_workshop,
            HasMarket = game.has_market,
            HasDlc = game.has_dlc,
            PlaytimeDisconnected = game.playtime_disconnected,
            HasCommunityVisibleStats = game.has_community_visible_stats,
            HasLeaderboards = game.has_leaderboards,
            Playtime2Weeks = game.playtime_2weeks
        });
    }

    public async Task<IEnumerable<LastPlayedTime>> GetLastPlayedTimesAsync(ulong steamId, int minLastPlayedTime = 0)
    {
        var url = $"IPlayerService/ClientGetLastPlayedTimes/v1/?key=A227FB5747B8B23208587AF679574C42&min_last_played=0";
        return await _client.GetAsync<IEnumerable<LastPlayedTime>>(url, "response/games");
        
    }

    public async Task<IEnumerable<OwnedGame>> GetRecentlyPlayedAsync(ulong steamId, int count = -1)
    {
        var url = $"IPlayerService/GetRecentlyPlayedGames/v1/?steamid={steamId}";
        if (count > 0)
            url += $"&count={count}";
        
        return await _client.GetAsync<IEnumerable<OwnedGame>>(url, "response/games");
    }
}