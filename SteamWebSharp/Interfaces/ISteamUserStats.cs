using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamWebSharp.Interfaces;
public interface ISteamUserStats
{
    Task<int> GetNumberOfCurrentPlayersAsync(int appId);
}
