﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamWebSharp;
public record PlayerBans
{
    public ulong SteamId { get; set; }
    public bool CommunityBanned { get; set; }
    public bool VACBanned { get; set; }
    public int NumberOfVACBans { get; set; }
    public int DaysSinceLastBan { get; set; }
    public int NumberOfGameBans { get; set; }
    public string EconomyBan { get; set; }
}
