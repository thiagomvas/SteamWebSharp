using SteamWebSharp.DTOs;
using SteamWebSharp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamWebSharp;
internal class SteamUserStatsEndpoints : ISteamUserStats
{
    private readonly SteamApiClient _client;

    public SteamUserStatsEndpoints(SteamApiClient client)
    {
        _client = client;
    }

    public async Task<IEnumerable<AchievementPercentage>> GetGlobalAchievementPercentagesForAppAsync(int appId)
    {
        var url = $"/ISteamUserStats/GetGlobalAchievementPercentagesForApp/v2?gameid={appId}";
        var response = await _client.GetAsync<GetGlobalAchievementPercentagesForAppResponse>(url);
        return response.AchievementPercentages.achievements.Select(a => new AchievementPercentage() { ApiName = a.name, Percentage = a.percent});
    }

    public async Task<int> GetNumberOfCurrentPlayersAsync(int appId)
    {
        var url = $"/ISteamUserStats/GetNumberOfCurrentPlayers/v1?appid={appId}";
        var response = await _client.GetAsync<GetNumberOfCurrentPlayersResponse>(url);
        return response.player_count;
    }

    public async Task<IEnumerable<PlayerAchievement>> GetPlayerAchievementsAsync(ulong steamId, int appId)
    {
        var url = $"/ISteamUserStats/GetPlayerAchievements/v1?steamid={steamId}&appid={appId}";
        var response = await _client.GetAsync<GetPlayerAchievementsResponse>(url);
        return response.PlayerStats.Achievements.Select(a => new PlayerAchievement
        {
            ApiName = a.ApiName,
            Achieved = a.Achieved == 1,
            UnlockTime = a.UnlockTime > 0 ? DateTimeOffset.FromUnixTimeSeconds((long)a.UnlockTime).DateTime : null,
            Description = a.Description
            
        });
    }

    public async Task<GameSchema> GetSchemaForGameAsync(int appId)
    {
        var url = $"/ISteamUserStats/GetSchemaForGame/v2?key={_client.ApiKey}&appid={appId}";
        var response = await _client.GetAsync<GetSchemaForGameResponse>(url);
        return new GameSchema
        {
            Name = response.GameName,
            Version = response.GameVersion,
            Achievements = response.AvailableGameStats.Achievements.Select(a =>
            {
                return new GameAchievement
                {
                    ApiName = a.Name,
                    DisplayName = a.DisplayName,
                    Description = a.Description,
                    Icon = a.Icon,
                    IconGray = a.IconGray,
                    IsHidden = a.Hidden == 1,
                };
            }).ToArray(),
            Stats = response.AvailableGameStats.Stats.Select(s =>
            {
                return new GameStat
                {
                    ApiName = s.Name,
                    DisplayName = s.DisplayName,
                    DefaultValue = s.DefaultValue
                };
            }).ToArray(),

        };
    }

    public async Task<PlayerStats> GetUserStatsForGameAsync(ulong steamId, int appId)
    {
        var url = $"/ISteamUserStats/GetUserStatsForGame/v2?steamid={steamId}&appid={appId}";
        var response = await _client.GetAsync<GetUserStatsForGameResponse>(url);

        return new PlayerStats
        {
            SteamId = ulong.Parse(response.PlayerStats.SteamId),
            
            GameName = response.PlayerStats.GameName,
            Stats = response.PlayerStats.Stats.Select(s =>
            {
                return new PlayerStat
                {
                    ApiName = s.Name,
                    Value = s.Value
                };
            }).ToArray(),
            Achievements = response.PlayerStats.Achievements.Select(a =>
            {
                return new PlayerAchievement
                {
                    ApiName = a.Name,
                    Achieved = a.Achieved == 1,
                    UnlockTime = a.UnlockTime > 0 ? DateTimeOffset.FromUnixTimeSeconds((long)a.UnlockTime).DateTime : null
                };
            }).ToArray(),
            Success = response.PlayerStats.Success
        };
    }
}
