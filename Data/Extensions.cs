using System.Text;
using Data.Enums.Race;
using Data.Models;
namespace Data;
internal static class Extensions
{
    private static readonly string _path = AppDomain.CurrentDomain.BaseDirectory;
    internal static string ToLabel(this Unit unit)
    {
        StringBuilder builder = new(256);
        builder.Append(unit.Name);

        if (unit.Slot.HasValue)
            builder.Append(' ').Append('[').Append(unit.Slot.Value).Append(']');

        if (unit.Evolution != Evolution.NA)
            builder.Append(' ').Append('[').Append(unit.Evolution).Append(']');

        return builder.ToString();
    }
    internal static Unit Clone(this Unit unit)
    {
        return new Unit
        {
            Name = unit.Name,
            CostPerUnit = unit.CostPerUnit,
            CostPerUnitReassign = unit.CostPerUnitReassign,
            Strenght = unit.Strenght,
            Type = unit.Type,
            Purpose = unit.Purpose,
            Evolution = unit.Evolution,
            Slot = unit.Slot
        };
    }
    internal static Race Clone(this Race unit)
    {
        return new Race
        {
            Name = unit.Name,
            Type = unit.Type,
            Evolution = unit.Evolution,
            Units = unit.Units?.Select(u => u.Clone()).ToList() ?? []
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
                $"{u.Strenght?.ToString() ?? "-"} | {u.Type} | {u.Purpose} | {u.Evolution} | {u.Slot?.ToString() ?? "-"} |"
            );
        }

        string fileName = $"units_{(title ?? "dump")}_{DateTime.Now:yyyyMMddHHmmssfff}.md";
        string path = Path.Combine(_path, fileName);

        File.WriteAllText(path, sb.ToString());
    }
    internal static List<Unit> MergeWith(this IEnumerable<Unit> overrides, IEnumerable<Unit> baseUnits)
    {
        var result = baseUnits
            .Select(u => u.Clone())
            .ToList();

        var lookup = result.ToDictionary(
            u => (u.Type, u.Purpose, u.Slot, u.CostPerUnit, u.Evolution)
        );

        foreach (var overrideUnit in overrides)
        {
            var key = (overrideUnit.Type, overrideUnit.Purpose, overrideUnit.Slot, overrideUnit.CostPerUnit, overrideUnit.Evolution);

            if (lookup.TryGetValue(key, out var existing))
            {
                if (overrideUnit.CostPerUnit != 0)
                    existing.CostPerUnit = overrideUnit.CostPerUnit;

                if (overrideUnit.CostPerUnitReassign.HasValue)
                    existing.CostPerUnitReassign = overrideUnit.CostPerUnitReassign;

                if (overrideUnit.Strenght.HasValue)
                    existing.Strenght = overrideUnit.Strenght;

                if (!string.IsNullOrWhiteSpace(overrideUnit.Name))
                    existing.Name = overrideUnit.Name;
            }
            else
            {
                result.Add(overrideUnit.Clone());
            }
        }

        return result;
    }
}
