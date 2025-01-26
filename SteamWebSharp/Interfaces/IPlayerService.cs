using SteamWebSharp.Models;

namespace SteamWebSharp.Interfaces;

public interface IPlayerService
{
    /// <summary>
    /// Get a list of games a player owns along with some playtime information.
    /// </summary>
    /// <param name="steamId">The player to fetch the owned games of</param>
    /// <param name="includeAppInfo"><see langword="true"/> to fetch additional details(name, icon) about each game</param>
    /// <param name="includePlayedFreeGames">Free games are excluded by default. If this is set, free games the user has played will be returned.</param>
    /// <param name="includeFreeSub">Some games are in the free sub, which are excluded by default.</param>
    /// <param name="includeExtendedAppInfo"><see langword="true"/> even more details (capsule, sortas, and capabilities) about each game. <paramref name="includeAppInfo"/> must also be <see langword="true"/>.</param>
    /// <returns>A list of owned games</returns>
    Task<IEnumerable<OwnedGame>> GetOwnedGamesAsync(ulong steamId, bool includeAppInfo = true, bool includePlayedFreeGames = false, bool includeFreeSub = false, bool includeExtendedAppInfo = false);
}