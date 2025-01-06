using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SteamWebSharp.Models;

namespace SteamWebSharp.Interfaces;
/// <summary>
/// Interface for interacting with Steam User Stats API.
/// Provides methods to retrieve player statistics, achievements, and game schema information.
/// </summary>
public interface ISteamUserStats
{
    /// <summary>
    /// Gets the number of current players for a game. Does not require a valid Steam Web API key.
    /// </summary>
    /// <param name="appId">
    /// The Steam App ID of the game to get the number of current players for.
    /// </param>
    /// <returns>
    /// A <see cref="Task{TResult}"/> representing the asynchronous operation. 
    /// The result contains the number of players currently playing the specified game.
    /// </returns>
    Task<int> GetNumberOfCurrentPlayersAsync(int appId);

    /// <summary>
    /// Gets the schema for a game, including achievements and stats. Requires a valid Steam Web API key.
    /// </summary>
    /// <param name="appId">The Steam App ID of the game to get the Game Schema for.</param>
    /// <returns>
    /// A <see cref="Task{TResult}"/> representing the asynchronous operation. 
    /// The result contains a <see cref="GameSchema"/> object with the schema for the specified game.
    /// </returns>
    Task<GameSchema> GetSchemaForGameAsync(int appId);

    /// <summary>
    /// Gets the global achievement percentages for a game. Does not require a valid Steam Web API key.
    /// </summary>
    /// <param name="appId">The Steam App ID of the game to get global achievement percentages for.</param>
    /// <returns>
    /// A <see cref="Task{TResult}"/> representing the asynchronous operation. 
    /// The result contains an <see cref="IEnumerable{T}"/> of <see cref="AchievementPercentage"/> objects.
    /// </returns>
    Task<IEnumerable<AchievementPercentage>> GetGlobalAchievementPercentagesForAppAsync(int appId);

    /// <summary>
    /// Gets the achievements of a specific player for a specific game. Requires a valid Steam Web API key.
    /// </summary>
    /// <param name="steamId">The Steam ID of the player to get achievements for.</param>
    /// <param name="appId">The Steam App ID of the game to get the player's achievements for.</param>
    /// <returns>
    /// A <see cref="Task{TResult}"/> representing the asynchronous operation. 
    /// The result contains an <see cref="IEnumerable{T}"/> of <see cref="PlayerAchievement"/> objects.
    /// </returns>
    Task<IEnumerable<PlayerAchievement>> GetPlayerAchievementsAsync(ulong steamId, int appId);

    /// <summary>
    /// Gets the user statistics for a specific game. Requires a valid Steam Web API key.
    /// </summary>
    /// <param name="steamId">The Steam ID of the user to get stats for.</param>
    /// <param name="appId">The Steam App ID of the game to get the stats for.</param>
    /// <returns>
    /// A <see cref="Task{TResult}"/> representing the asynchronous operation. 
    /// The result contains a <see cref="PlayerStats"/> object with the user's stats for the specified game.
    /// </returns>
    Task<PlayerStats> GetUserStatsForGameAsync(ulong steamId, int appId);
}

