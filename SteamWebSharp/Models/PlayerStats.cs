namespace SteamWebSharp.Models;

/// <summary>
/// Represents a player's stats in a game.
/// </summary>
public record PlayerStats
{
    /// <summary>
    /// The Steam ID of the player.
    /// </summary>
    public ulong SteamId { get; init; }

    /// <summary>
    /// The name of the game.
    /// </summary>
    public string GameName { get; init; }

    /// <summary>
    /// The achievements with the player's values.
    /// </summary>
    public PlayerAchievement[] Achievements { get; init; }

    /// <summary>
    /// The stats with the player's values.
    /// </summary>
    public PlayerStat[] Stats { get; init; }

    /// <summary>
    /// Whether the request was successful.
    /// </summary>
    public bool Success { get; init; }
}
