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
        return Utils.ExtractResponse<PlayerBans>(response);
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
}
