using SteamWebSharp.DTOs.TeamFortress;
using SteamWebSharp.Models.TeamFortress;

namespace SteamWebSharp.Interfaces;

/// <summary>
///     Represents the interface for interacting with 'Team Fortress 2'-related API endpoints.
/// </summary>
public interface ITeamFortress
{
    /// <summary>
    ///     Fetch Team Fortress 2 items owned by a player.
    /// </summary>
    /// <param name="steamId">The Steam ID to fetch items for.</param>
    /// <returns>
    ///     An <see cref="IEnumerable{T}" /> of <see cref="TeamFortressPlayerItem" /> representing the items owned by the
    ///     player.
    /// </returns>
    public Task<IEnumerable<GetPlayerItemsResponse>> GetPlayerItemsAsync(ulong steamId);
}