namespace Data.Models;
public sealed class Game
{
    public string Name { get; set; } = string.Empty;
    public string Url { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public Enums.Game.Type Type { get; set; } = Enums.Game.Type.Main;
    public List<Race> Races { get; set; } = [];
    public List<Enums.Calculator.Type> Calculators { get; set; } = [];
}
