namespace Data.Models;
public sealed class ActiveUser
{
    public required List<Game> Games { get; set; }
    public required User User { get; set; }
    public required Account ActiveAccount { get; set; }
    public required Game ActiveGame { get; set; }
    public required Race ActiveRace { get; set; }
}
