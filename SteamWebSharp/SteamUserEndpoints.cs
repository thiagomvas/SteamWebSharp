using SteamWebSharp.DTOs;
using SteamWebSharp;
using SteamWebSharp.Interfaces;
using SteamWebSharp.Models;

namespace SteamWebSharp;
public class SteamUserEndpoints : ISteamUser
{
    private readonly SteamApiClient _client;

    public SteamUserEndpoints(SteamApiClient client)
    {
        _client = client;
    }

    public async Task<ulong> ResolveVanityURLAsync(string vanityUrl)
    {
        var result = await _client.GetAsync<ResolveVanityURLResponse>($"/ISteamUser/ResolveVanityURL/v1/?vanityurl={vanityUrl}");
        return ulong.Parse(result.SteamId);
    }

    public async Task<PlayerBans> GetPlayerBansAsync(ulong steamId)
    {
        var result = await _client.GetAsync<GetPlayerBansResponse>($"/ISteamUser/GetPlayerBans/v1/?steamids={steamId}");
        var player = result.Players.FirstOrDefault();
        return player != null ? MapPlayerBans(player) : null;
    }

    public async Task<IEnumerable<Friend>> GetFriendListAsync(ulong steamId)
    {
        var result = await _client.GetAsync<GetFriendListResponse>($"/ISteamUser/GetFriendList/v1/?steamid={steamId}&relationship=friend");
        return result.Friends.Select(f => new Friend
        {
            SteamId = f.steamid,
            Relationship = f.relationship,
            FriendSince = DateTimeOffset.FromUnixTimeSeconds(f.friend_since).DateTime
        });
    }

    public async Task<IEnumerable<Group>> GetUserGroupListAsync(ulong steamId)
    {
        var result = await _client.GetAsync<GetUserGroupListResponse>($"/ISteamUser/GetUserGroupList/v1/?steamid={steamId}");
        return result.Groups.Select(g => new Group { Gid = ulong.Parse(g.Gid) });
    }

    public async Task<PlayerSummary> GetPlayerSummariesAsync(ulong steamId)
    {
        var result = await _client.GetAsync<GetPlayerSummariesResponse>($"/ISteamUser/GetPlayerSummaries/v2/?steamids={steamId}");
        var user = result.players.FirstOrDefault();
        return user != null ? MapPlayerSummary(user) : null;
    }

    public async Task<IEnumerable<PlayerBans>> GetPlayerBansAsync(IEnumerable<ulong> steamIds)
    {
        var result = await _client.GetAsync<GetPlayerBansResponse>($"/ISteamUser/GetPlayerBans/v1/?steamids={string.Join(",", steamIds)}");
        return result.Players.Select(MapPlayerBans);
    }

    public async Task<IEnumerable<PlayerSummary>> GetPlayerSummariesAsync(IEnumerable<ulong> steamIds)
    {
        var result = await _client.GetAsync<GetPlayerSummariesResponse>($"/ISteamUser/GetPlayerSummaries/v2/?steamids={string.Join(",", steamIds)}");
        return result.players.Select(MapPlayerSummary);
    }

    // Helper methods to map responses
    private PlayerBans MapPlayerBans(PlayerBansDto player)
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

    private PlayerSummary MapPlayerSummary(PlayerSummariesDTO user)
    {
        return new PlayerSummary
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
        };
    }
}
