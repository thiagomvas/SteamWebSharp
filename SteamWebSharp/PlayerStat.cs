using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamWebSharp;
public record PlayerStat
{
    public string ApiName { get; set; }
    public ulong Value { get; set; }
}
