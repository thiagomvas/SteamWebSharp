using SteamWebSharp.DTOs;
using SteamWebSharp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamWebSharp;
public class SteamApiClient : ISteamUser
{
    private readonly HttpClient _httpClient;
    private readonly string _apiKey;
    private const string _baseUrl = "https://api.steampowered.com";

    public SteamApiClient(string apiKey)
    {
        _apiKey = apiKey;
        _httpClient = new HttpClient();
    }

    public async Task<ulong> ResolveVanityURLAsync(string vanityUrl)
    {
        var url = $"{_baseUrl}/ISteamUser/ResolveVanityURL/v1/?key={_apiKey}&vanityurl={vanityUrl}";
        var response = await _httpClient.GetStringAsync(url);
        var result = Utils.ExtractResponse<ResolveVanityURLResponse>(response);
        return ulong.Parse(result.SteamId);
    }

    public async Task<PlayerBans> GetPlayerBansAsync(ulong steamId)
    {
        var url = $"{_baseUrl}/ISteamUser/GetPlayerBans/v1/?key={_apiKey}&steamids={steamId}";
        var response = await _httpClient.GetStringAsync(url);
        var result = Utils.ExtractResponse<GetPlayerBansResponse>(response);
        var player = result.Players.FirstOrDefault();

        if (player != null)
        {
            return new PlayerBans
            {
                SteamId = ulong.Parse(player.SteamId),
                CommunityBanned = player.CommunityBanned,
                VACBanned = player.VACBanned,
                NumberOfVACBans = player.NumberOfVACBans,
                DaysSinceLastBan = player.DaysSinceLastBan,
                NumberOfGameBans = player.NumberOfGameBans,
                EconomyBan = player.EconomyBan
            };
        }

        return null;
    }

    public async Task<IEnumerable<Friend>> GetFriendListAsync(ulong steamId)
    {
        var url = $"{_baseUrl}/ISteamUser/GetFriendList/v1/?key={_apiKey}&steamid={steamId}&relationship=friend";
        var response = await _httpClient.GetStringAsync(url);
        var result = Utils.ExtractResponse<GetFriendListResponse>(response);

        return result.Friends.Select(f => new Friend
        {
            SteamId = f.steamid,
            Relationship = f.relationship,
            FriendSince = DateTimeOffset.FromUnixTimeSeconds(f.friend_since).DateTime
        });
    }

    public async Task<IEnumerable<Group>> GetUserGroupListAsync(ulong steamId)
    {
        var url = $"{_baseUrl}/ISteamUser/GetUserGroupList/v1/?key={_apiKey}&steamid={steamId}";
        var response = await _httpClient.GetStringAsync(url);
        var result = Utils.ExtractResponse<GetUserGroupListResponse>(response);

        return result.Groups.Select(g => new Group
        {
            Gid = ulong.Parse(g.Gid)
        });

    }

    public async Task<PlayerSummary> GetPlayerSummaryAsync(ulong steamId)
    {
        var url = $"{_baseUrl}/ISteamUser/GetPlayerSummaries/v2/?key={_apiKey}&steamids={steamId}";
        var response = await _httpClient.GetStringAsync(url);
        var result = Utils.ExtractResponse<GetPlayerSummariesResponse>(response);
        var user = result.players.FirstOrDefault();

        return new PlayerSummary
        {
            SteamId = ulong.Parse(user.steamid),
            PersonaName = user.personaname,
            ProfileUrl = user.profileurl,
            Avatar = user.avatar,
            AvatarMedium = user.avatarmedium,
            AvatarFull = user.avatarfull,
            PersonaState = (ProfileState) user.personastate,
            CommunityVisibilityState = user.communityvisibilitystate,
            ProfileState = user.profilestate,
            LastLogOff = DateTimeOffset.FromUnixTimeSeconds(user.lastlogoff).DateTime,
            RealName = user.realname,
            PrimaryClanId = ulong.Parse(user.primaryclanid),
            TimeCreated = DateTimeOffset.FromUnixTimeSeconds(user.timecreated).DateTime,
            PersonaStateFlags = user.personastateflags,
            LocCountryCode = user.loccountrycode,
            LocStateCode = user.locstatecode,
            LocCityId = user.loccityid
        };

    }

    public async Task<IEnumerable<PlayerBans>> GetPlayerBansAsync(IEnumerable<ulong> steamIds)
    {
        var url = $"{_baseUrl}/ISteamUser/GetPlayerBans/v1/?key={_apiKey}&steamids={string.Join(",", steamIds)}";
        var response = await _httpClient.GetStringAsync(url);
        var result = Utils.ExtractResponse<GetPlayerBansResponse>(response);

        return result.Players.Select(p => new PlayerBans
        {
            SteamId = ulong.Parse(p.SteamId),
            CommunityBanned = p.CommunityBanned,
            VACBanned = p.VACBanned,
            NumberOfVACBans = p.NumberOfVACBans,
            DaysSinceLastBan = p.DaysSinceLastBan,
            NumberOfGameBans = p.NumberOfGameBans,
            EconomyBan = p.EconomyBan
        });
    }

    public async Task<IEnumerable<PlayerSummary>> GetPlayerSummariesAsync(IEnumerable<ulong> steamIds)
    {
        var url = $"{_baseUrl}/ISteamUser/GetPlayerSummaries/v2/?key={_apiKey}&steamids={string.Join(",", steamIds)}";
        var response = await _httpClient.GetStringAsync(url);
        var result = Utils.ExtractResponse<GetPlayerSummariesResponse>(response);

        return result.players.Select(user => new PlayerSummary
        {
            SteamId = ulong.Parse(user.steamid),
            PersonaName = user.personaname,
            ProfileUrl = user.profileurl,
            Avatar = user.avatar,
            AvatarMedium = user.avatarmedium,
            AvatarFull = user.avatarfull,
            PersonaState = (ProfileState)user.personastate,
            CommunityVisibilityState = user.communityvisibilitystate,
            ProfileState = user.profilestate,
            LastLogOff = DateTimeOffset.FromUnixTimeSeconds(user.lastlogoff).DateTime,
            RealName = user.realname,
            PrimaryClanId = ulong.Parse(user.primaryclanid),
            TimeCreated = DateTimeOffset.FromUnixTimeSeconds(user.timecreated).DateTime,
            PersonaStateFlags = user.personastateflags,
            LocCountryCode = user.loccountrycode,
            LocStateCode = user.locstatecode,
            LocCityId = user.loccityid
        });
    }
}
