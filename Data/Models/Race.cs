using Data.Enums.Race;
namespace Data.Models;
public sealed class Race
{
    public string Name { get; set; } = string.Empty;
    public Currency Currency { get; set; } = new Currency();
    public bool Enabled { get; set; } = true;
    public List<Unit> Units { get; set; } = [];
    public Enums.Game.Type Type { get; set; } = Enums.Game.Type.Main;
    public Evolution Evolution { get; set; } = Evolution.Basic;
}
