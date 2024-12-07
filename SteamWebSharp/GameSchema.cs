﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamWebSharp;
public class GameSchema
{
    public string Name { get; set; }
    public string Version { get; set; }
    public GameAchievement[] Achievements { get; set; }
    public GameStat[] Stats { get; set; }

}
