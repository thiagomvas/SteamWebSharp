namespace SteamWebSharp.Models.TeamFortress;

public class TeamFortressItemAttribute
{
    public int Defindex { get; set; }
    public object Value { get; set; }
    public double FloatValue { get; set; }
    public bool IsOutput { get; set; }
    public int Quantity { get; set; }
    public int Quality { get; set; }
    public bool MatchAllAttribs { get; set; }
    public int Itemdef { get; set; }
    
}