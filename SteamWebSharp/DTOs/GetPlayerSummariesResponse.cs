using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamWebSharp.DTOs;
internal class GetPlayerSummariesResponse
{
    public PlayerSummariesDTO[] players { get; set; }
}
public record PlayerSummariesDTO
{
    public string steamid { get; set; }
    public int communityvisibilitystate { get; set; }
    public int profilestate { get; set; }
    public string personaname { get; set; }
    public string profileurl { get; set; }
    public string avatar { get; set; }
    public string avatarmedium { get; set; }
    public string avatarfull { get; set; }
    public string avatarhash { get; set; }
    public int lastlogoff { get; set; }
    public int personastate { get; set; }
    public string realname { get; set; }
    public string primaryclanid { get; set; }
    public int timecreated { get; set; }
    public int personastateflags { get; set; }
    public string loccountrycode { get; set; }
    public string locstatecode { get; set; }
    public string loccityid { get; set; }
}