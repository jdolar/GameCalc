using Data.Models;
using System.Text;
namespace Data;

public static class Hints
{
    private const string _delimeter = ": ";
    public static string GetAbleToBuyHint(string inputAmount, string currency, string resultAmount, Unit unit)
    {
        StringBuilder builder = new(256);

        builder.Append("You can buy ")
          .Append(resultAmount)
          .Append(' ')
          .Append(unit.Name)
          .Append("(s) for ")
          .Append(inputAmount)
          .Append(' ')
          .Append(currency)
          .Append('.');

        return builder.ToString();
    }
    public static string GetCostToBuyHint(string inputAmount, string currency, string resultAmount, string operation, Unit unit)
    {
        StringBuilder builder = new(256);

        builder.Append("It would cost ")
          .Append(resultAmount)
          .Append(' ')
          .Append(currency)
          .Append(' ')
          .Append(operation)
          .Append(' ')
          .Append(inputAmount)
          .Append(' ')
          .Append(unit.Name)
          .Append("(s).");

        return builder.ToString();
    }
    public static string GetUnit(Unit unit)
    {
        StringBuilder builder = new(128);

        builder.Append(Constants.GUI.Labels.CostPerUnit).Append(_delimeter).Append(unit.CostPerUnit).AppendLine();

        if (unit.CostPerUnitReassign is int reassign)
            builder.Append(Constants.GUI.Labels.CostPerUnitReassign).Append(_delimeter).Append(reassign).AppendLine();

        if (unit.Strenght is int strength)
            builder.Append(Constants.GUI.Labels.Strenght).Append(_delimeter).Append(strength).AppendLine();

        builder.Append(Constants.GUI.Labels.Type).Append(_delimeter).Append(unit.Type).AppendLine();
        builder.Append(Constants.GUI.Labels.Purpose).Append(_delimeter).Append(unit.Purpose);

        return builder.ToString();
    }
    public static string GetRace(Race? race)
    {
        if (race == null || race.Units.Count == 0)
            return "Race not available.";

        StringBuilder builder = new();
        builder.Append(race.Name).AppendLine();
        builder.Append(nameof(race.Type)).Append(_delimeter).Append(race.Type).AppendLine();
        builder.Append(nameof(race.Evolution)).Append(_delimeter).Append(race.Evolution).AppendLine();
        builder.Append(nameof(race.Currency)).Append(_delimeter).Append(race.Currency.Name).AppendLine();
        builder.AppendLine(GetUnits(race.Units));

        return builder.ToString();
    }
    public static string UpCalcDesiredUpResults(string fromInput, string toInput, string result, string multiplier, string currency)
    {
        StringBuilder builder = new();

        builder.Append("From ");
        builder.Append(fromInput);
        builder.Append(" unit production to reach ");
        builder.Append(toInput);
        builder.Append(" you will need...");
        builder.AppendLine();
        builder.Append("        * ").Append(result).Append(' ').Append(currency);
        builder.AppendLine();
        builder.Append("        * Multipliert to enter is ").Append(multiplier);

        return builder.ToString();
    }
    public static string UpCalcResurcesToSpendResults(string fromInput, string totalCostInput, string result, string multiplier, string currency)
    {//From 1,000,002 unit production with 1,041,663,749,995,000 Naquadah you can upgrade to...
        StringBuilder builder = new();

        builder.Append("From ");
        builder.Append(fromInput);
        builder.Append(" unit production with ");
        builder.Append(totalCostInput);
        builder.Append(' ');
        builder.Append(currency);
        builder.Append(" you can upgrade to...");
        builder.AppendLine();
        builder.Append("        * ").Append(result).Append(" unit production.");
        builder.AppendLine();
        builder.Append("        * Multipliert to enter is ").Append(multiplier);

        return builder.ToString();
    }
    public static string GetUnits(List<Unit> units)
    {
        if (units == null || units.Count == 0)
            return "No units available.";

        var groups = units.GroupBy(u => u.Type).OrderByDescending(g => g.Key);

        StringBuilder builder = new();
        foreach (var group in groups)
        {
            var sortedUnits = group.GroupBy(u => u.Purpose).OrderByDescending(g => g.Key);
            builder.AppendLine($"----- {group.Key.ToString()}(s) -----");
            foreach (var sortedUnit in sortedUnits)
            {
                builder.AppendLine($"           {sortedUnit.Key} {group.Key.ToString()}(s)");
                foreach (var unit in sortedUnit)
                {
                    builder.Append("                    ").Append(unit.ToLabel()).AppendLine();
                }
            }
        }

        return builder.ToString();
    }
    public static string GetGame(Game? game)
    {
        if (game is null)
            return "No game available.";

        StringBuilder builder = new();

        builder.Append(nameof(game.Name)).Append(_delimeter).Append(game.Name)
               .AppendLine()
               .Append(nameof(game.Type)).Append(_delimeter).Append(game.Type)
               .AppendLine()
               .Append(nameof(game.Url)).Append(_delimeter).Append(game.Url);

        if (!string.IsNullOrEmpty(game.Description))
            builder.AppendLine().Append(nameof(game.Description)).Append(_delimeter).Append(game.Description);

        return builder.ToString();
    }
}
