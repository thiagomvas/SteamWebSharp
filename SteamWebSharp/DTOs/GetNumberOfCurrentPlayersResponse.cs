using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamWebSharp.DTOs;
internal class GetNumberOfCurrentPlayersResponse
{
    public int player_count { get; set; }
    public int result { get; set; }
}
