namespace SteamWebSharp.DTOs;
internal class GetFriendListResponse
{
    public FriendDto[] Friends { get; set; }
}

internal class FriendDto
{
    public string steamid { get; set; }
    public string relationship { get; set; }
    public long friend_since { get; set; }
}
