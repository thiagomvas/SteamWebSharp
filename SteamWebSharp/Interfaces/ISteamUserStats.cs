using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamWebSharp.Interfaces;
public interface ISteamUserStats
{
    /// <summary>
    /// Gets the number of current players for a game. Does not require a valid Steam Web API key.
    /// </summary>
    /// <param name="appId">
    /// The Steam App ID of the game to get the number of current players for.
    /// </param>
    /// <returns>The number of players currently playing the specified game.</returns>
    Task<int> GetNumberOfCurrentPlayersAsync(int appId);

    /// <summary>
    /// Gets the schema for a game, including achievements and stats. Requires a valid Steam Web API key.
    /// </summary>
    /// <param name="appId">The Steam App ID of the game to get the Game Schema for.</param>
    /// <returns>
    /// A <see cref="GameSchema"/> object containing the schema for the specified game.
    /// </returns>
    Task<GameSchema> GetSchemaForGameAsync(int appId);

    
    Task<IEnumerable<AchievementPercentage>> GetGlobalAchievementPercentagesForAppAsync(int appId);
}
