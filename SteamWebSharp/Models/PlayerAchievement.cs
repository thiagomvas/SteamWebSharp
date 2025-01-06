namespace SteamWebSharp.Models;

/// <summary>
/// Represents a player achievement.
/// </summary>
public record PlayerAchievement
{
    /// <summary>
    /// The API name of the achievement.
    /// </summary>
    public string ApiName { get; set; }

    /// <summary>
    /// Whether the achievement has been unlocked.
    /// </summary>
    public bool Achieved { get; set; }

    /// <summary>
    /// If it has been unlocked, the time it was unlocked, <see langword="null"/> otherwise.
    /// </summary>
    public DateTime? UnlockTime { get; set; }

    public string Description { get; set; }
}
