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
    public async Task<int> GetNumberOfCurrentPlayersAsync(int appId)
    {
        var url = $"/ISteamUserStats/GetNumberOfCurrentPlayers/v1?appid={appId}";
        var response = await _client.GetAsync<GetNumberOfCurrentPlayersResponse>(url);
        return response.player_count;
    }
}
