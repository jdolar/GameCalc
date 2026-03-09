using Data.Enums.Race;
using Data.Enums.Unit;
namespace Data.Models;
public sealed class Unit
{
    public string Name { get; set; } = "Unknown";
    public int CostPerUnit { get; set; } = default;
    public int? CostPerUnitReassign { get; set; } = null;
    public int? Strenght { get; set; } = null;
    public Enums.Unit.Type Type { get; set; }
    public Purpose Purpose { get; set; }
    public Evolution Evolution { get; set; } = Evolution.NA;
    public int? Slot { get; set; } = null;
}
