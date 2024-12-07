using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamWebSharp.Interfaces;
public interface ISteamUser
{
    Task<ulong> ResolveVanityURLAsync(string vanityUrl);
    Task<PlayerBans> GetPlayerBansAsync(ulong steamId);
    Task<IEnumerable<PlayerBans>> GetPlayerBansAsync(IEnumerable<ulong> steamIds);
    Task<IEnumerable<Friend>> GetFriendListAsync(ulong steamId);
    Task<IEnumerable<Group>> GetUserGroupListAsync(ulong steamId);
    Task<PlayerSummary> GetPlayerSummaryAsync(ulong steamId);
    Task<IEnumerable<PlayerSummary>> GetPlayerSummariesAsync(IEnumerable<ulong> steamIds);
}
