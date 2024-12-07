using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamWebSharp;
public record GameStat
{
    public string ApiName { get; set; }
    public string DisplayName { get; set; }
    public int DefaultValue { get; set; }
}
