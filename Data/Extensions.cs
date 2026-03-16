using System.Text;
using Data.Models;
using Data.Enums.Race;
namespace Data;
internal static class Extensions
{
    private static readonly string _path = AppDomain.CurrentDomain.BaseDirectory;
    internal static Unit Clone(this Unit unit)
    {
        return new Unit
        {
            Name = unit.Name,
            CostPerUnit = unit.CostPerUnit,
            CostPerUnitReassign = unit.CostPerUnitReassign,
            Strength = unit.Strength,
            Type = unit.Type,
            Purpose = unit.Purpose,
            Evolution = unit.Evolution,
            Slot = unit.Slot
        };
    }
    internal static Race Clone(this Race race)
    {
        return new Race
        {
            Name = race.Name,
            Type = race.Type,
            Evolution = race.Evolution,
            Currency = race.Currency,
            Units = race.Units?.Select(u => u.Clone()).ToList() ?? []
        };
    }
    internal static List<Unit> CloneUnits(this List<Unit> units)
    {
        return [.. units.Select(u => u.Clone())];
    }
    internal static void DumpToFile(this List<Unit> units, string? title = null)
    {
        if (units == null || units.Count == 0)
            return;

        var sb = new StringBuilder();

        sb.AppendLine(title ?? "Units Dump");
        sb.AppendLine(new string('=', 50));
        sb.AppendLine("| Name | Cost | ReassignCost | Strength | Type | Purpose | Evolution | Slot |");
        sb.AppendLine("|------|------|--------------|---------|------|---------|-----------|------|");

        foreach (var u in units.OrderBy(u => u.Name))
        {
            sb.AppendLine(
                $"| {u.Name} | {u.CostPerUnit} | {u.CostPerUnitReassign?.ToString() ?? "-"} | " +
                $"{u.Strength?.ToString() ?? "-"} | {u.Type} | {u.Purpose} | {u.Evolution} | {u.Slot?.ToString() ?? "-"} |"
            );
        }

        string fileName = $"units_{(title ?? "dump")}_{DateTime.Now:yyyyMMddHHmmssfff}.md";
        string path = Path.Combine(_path, fileName);

        File.WriteAllText(path, sb.ToString());
    }
    internal static List<Unit> MergeWith(this IEnumerable<Unit> overrides, IEnumerable<Unit> baseUnits, Evolution raceEvolution)
    {
        var result = baseUnits.Select(u => u.Clone()).ToList();

        foreach (var overrideUnit in overrides)
        {
            // 1️ Try exact match (Type, Purpose, Slot, Evolution)
            var exactMatch = result.FirstOrDefault(u =>
                u.Type == overrideUnit.Type &&
                u.Purpose == overrideUnit.Purpose &&
                u.Slot == overrideUnit.Slot &&
                u.Evolution == overrideUnit.Evolution
            );

            Unit? target;
            if (exactMatch != null)
            {
                target = exactMatch;
            }
            else
            {
                // 2️ Fall back: match by race evolution if override evolution mismatched
                target = result.FirstOrDefault(u =>
                    u.Type == overrideUnit.Type! &&
                    u.Purpose == overrideUnit.Purpose! &&
                    u.Slot == overrideUnit.Slot! &&
                    u.Evolution == raceEvolution!
                );
            }

            // 3️ If still nothing, add new unit
            if (target != null)
            {
                if (overrideUnit.CostPerUnit != 0)
                    target.CostPerUnit = overrideUnit.CostPerUnit;

                if (overrideUnit.CostPerUnitReassign.HasValue)
                    target.CostPerUnitReassign = overrideUnit.CostPerUnitReassign;

                if (overrideUnit.Strength.HasValue)
                    target.Strength = overrideUnit.Strength;

                if (!string.IsNullOrWhiteSpace(overrideUnit.Name))
                    target.Name = overrideUnit.Name;
            }
            else
            {
                result.Add(overrideUnit.Clone());
            }
        }

        return result;
    } 
}
