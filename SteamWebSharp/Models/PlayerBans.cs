namespace SteamWebSharp.Models;

/// <summary>
/// Represents a player's ban status.
/// </summary>
public record PlayerBans
{
    /// <summary>
    /// The player's Steam ID.
    /// </summary>
    public ulong SteamId { get; set; }

    /// <summary>
    /// Whether the player is banned from the Steam Community.
    /// </summary>
    public bool CommunityBanned { get; set; }

    /// <summary>
    /// Whether the player has a VAC ban.
    /// </summary>
    public bool VACBanned { get; set; }

    /// <summary>
    /// The amount of VAC bans the player has.
    /// </summary>
    public int NumberOfVACBans { get; set; }

    /// <summary>
    /// The amount of days since the player's last VAC ban.
    /// </summary>
    public int DaysSinceLastBan { get; set; }

    /// <summary>
    /// The amount of game bans the player has.
    /// </summary>
    public int NumberOfGameBans { get; set; }

    /// <summary>
    /// The player's economy ban status.
    /// </summary>
    public string EconomyBan { get; set; }
}
