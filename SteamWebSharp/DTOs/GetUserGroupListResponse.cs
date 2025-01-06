namespace SteamWebSharp.DTOs;

internal class GetUserGroupListResponse
{
    public GroupDto[] Groups { get; set; }
}

internal class GroupDto
{
    public string Gid { get; set; }
}