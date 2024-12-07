namespace SteamWebSharp.Interfaces;
/// <summary>
/// Represents the interface for interacting with Steam user-related API endpoints.
/// </summary>
public interface ISteamUser
{
    /// <summary>
    /// Resolves a Steam vanity URL (custom user profile URL) to a Steam ID. Requires a valid Steam Web API key.
    /// </summary>
    /// <param name="vanityUrl">The custom vanity URL to resolve (e.g., "steamcommunity.com/id/username").</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the resolved Steam ID.</returns>
    Task<ulong> ResolveVanityURLAsync(string vanityUrl);

    /// <summary>
    /// Retrieves the player bans for a given Steam user. Requires a valid Steam Web API key.
    /// </summary>
    /// <param name="steamId">The Steam ID of the user.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains a <see cref="PlayerBans"/> object with ban details.</returns>
    Task<PlayerBans> GetPlayerBansAsync(ulong steamId);

    /// <summary>
    /// Retrieves the player bans for a list of Steam users. Requires a valid Steam Web API key.
    /// </summary>
    /// <param name="steamIds">The Steam IDs of the users.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains an enumerable collection of <see cref="PlayerBans"/> objects, one for each user.</returns>
    Task<IEnumerable<PlayerBans>> GetPlayerBansAsync(IEnumerable<ulong> steamIds);

    /// <summary>
    /// Retrieves the friend list for a given Steam user. Requires a valid Steam Web API key.
    /// </summary>
    /// <param name="steamId">The Steam ID of the user.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains an enumerable collection of <see cref="Friend"/> objects representing the user's friends.</returns>
    Task<IEnumerable<Friend>> GetFriendListAsync(ulong steamId);

    /// <summary>
    /// Retrieves the user groups for a given Steam user. Requires a valid Steam Web API key.
    /// </summary>
    /// <param name="steamId">The Steam ID of the user.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains an enumerable collection of <see cref="Group"/> objects representing the groups the user is a member of.</returns>
    Task<IEnumerable<Group>> GetUserGroupListAsync(ulong steamId);

    /// <summary>
    /// Retrieves the player summary for a given Steam user. Requires a valid Steam Web API key.
    /// </summary>
    /// <param name="steamId">The Steam ID of the user.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains a <see cref="PlayerSummary"/> object with the user's profile and other details.</returns>
    Task<PlayerSummary> GetPlayerSummariesAsync(ulong steamId);

    /// <summary>
    /// Retrieves the player summaries for a list of Steam users. Requires a valid Steam Web API key.
    /// </summary>
    /// <param name="steamIds">The Steam IDs of the users.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains an enumerable collection of <see cref="PlayerSummary"/> objects, one for each user.</returns>
    Task<IEnumerable<PlayerSummary>> GetPlayerSummariesAsync(IEnumerable<ulong> steamIds);
}

