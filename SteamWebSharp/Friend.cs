namespace SteamWebSharp;
public record Friend
{
    public string SteamId { get; set; }
    public string Relationship { get; set; }
    public DateTime FriendSince { get; set; }
}
