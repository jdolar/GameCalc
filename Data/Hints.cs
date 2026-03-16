using Data.Models;
using System.Text;
namespace Data;
public static class Hints
{
    private const string _delimiter = ": ";
    private const string _bulletin = "        * ";
    private const string _line = "-----";
    private const string _space = "           ";
    public static string Unit(Unit unit)
    {
        StringBuilder builder = new(128);

        builder.Append(Constants.GUI.Hints.CostPerUnit).Append(_delimiter).Append(unit.CostPerUnit).AppendLine();

        if (unit.CostPerUnitReassign is int reassign)
            builder.Append(Constants.GUI.Hints.CostPerUnitReassign).Append(_delimiter).Append(reassign).AppendLine();

        if (unit.Strenght is int strength)
            builder.Append(Constants.GUI.Hints.Strenght).Append(_delimiter).Append(strength).AppendLine();

        builder.Append(Constants.GUI.Hints.Type).Append(_delimiter).Append(unit.Type).AppendLine();
        builder.Append(Constants.GUI.Hints.Purpose).Append(_delimiter).Append(unit.Purpose).AppendLine();

        if (unit.Slot is int slot)
            builder.Append(Constants.GUI.Hints.Slot).Append(_delimiter).Append(slot).AppendLine();

        return builder.ToString();
    }
    public static string Race(Race? race)
    {
        if (race == null || race.Units.Count == 0)
            return string.Format(Constants.GUI.Labels.NotAvailable, "Race");

        StringBuilder builder = new();
        builder.Append(race.Name).AppendLine();
        builder.Append(nameof(race.Type)).Append(_delimiter).Append(race.Type).AppendLine();
        builder.Append(nameof(race.Evolution)).Append(_delimiter).Append(race.Evolution).AppendLine();
        builder.Append(nameof(race.Currency)).Append(_delimiter).Append(race.Currency.Name).AppendLine();
        builder.AppendLine(Units(race.Units));

        return builder.ToString();
    }
    public static string Units(List<Unit> units)
    {
        if (units == null || units.Count == 0)
            return string.Format(Constants.GUI.Labels.NotAvailable, "Units");

        int maxNameLength = units.Max(u => u.Name?.Length ?? 0);
        int maxPriceLength = units.Max(u => $"{u.CostPerUnit}/unit".Length);

        var groups = units.GroupBy(u => u.Type)
                          .OrderByDescending(g => g.Key);

        StringBuilder builder = new();

        foreach (var group in groups)
        {
            var sortedUnits = group.GroupBy(u => u.Purpose)
                                   .OrderByDescending(g => g.Key);

            builder.Append(_line)
                   .Append(' ')
                   .Append(group.Key)
                   .Append(" (s)")
                   .AppendLine();

            foreach (var purposeGroup in sortedUnits)
            {
                builder.Append(_space)
                       .Append(purposeGroup.Key)
                       .Append(' ')
                       .Append(group.Key)
                       .Append("(s)")
                       .AppendLine();

                foreach (var unit in purposeGroup)
                {
                    string name = unit.Name ?? "";
                    string price = $"{unit.CostPerUnit}/unit";

                    builder.Append(_space)
                           .Append(_space)
                           .Append(name.PadRight(maxNameLength + 4))
                           .Append(price.PadLeft(maxPriceLength))
                           .AppendLine();
                }
            }
        }

        return builder.ToString();
    }
    public static string Units_old(List<Unit> units)
    {
        if (units == null || units.Count == 0)
            return string.Format(Constants.GUI.Labels.NotAvailable, "Units");

        var groups = units.GroupBy(u => u.Type).OrderByDescending(g => g.Key);

        StringBuilder builder = new();
        
        foreach (var group in groups)
        {
            //int maxNameLength = group.Max(u => u.Name?.Length ?? 0);
            int maxNameLength = group.Max(u => u.Name?.Length ?? 0);
            int maxPriceLength = group.Max(u => $"{u.CostPerUnit}/unit".Length);
            var sortedUnits = group.GroupBy(u => u.Purpose).OrderByDescending(g => g.Key);
            builder.Append(_line).Append(' ').Append(group.Key.ToString()).Append(' ').Append("(s)").AppendLine();
            foreach (var sortedUnit in sortedUnits)
            {
                builder.Append(_space).Append(sortedUnit.Key).Append(' ').Append(group.Key.ToString()).Append("(s)").AppendLine();
                             
                foreach (var unit in sortedUnit)
                {
                  //  builder.Append(_space).Append(_space).Append(unit.ToLabel()).AppendLine();
                }
                
                //int maxNameLength = sortedUnit.Max(u => u.Name?.Length ?? 0);

                var lines = sortedUnit.Select(u =>
                {
                    string name = u.Name ?? "";
                    string price = $"{u.CostPerUnit}/unit";

                    return name.PadRight(maxNameLength + 4) + price.PadLeft(maxPriceLength);
                });

                builder.Append(_space).Append(_space).Append(string.Join(Environment.NewLine, lines)).AppendLine();
            }
        }

        return builder.ToString();
    }
    public static string Game(Game? game)
    {
        if (game is null)
            return string.Format(Constants.GUI.Labels.NotAvailable, "Game");

        StringBuilder builder = new();

        builder.Append(nameof(game.Name)).Append(_delimiter).Append(game.Name).AppendLine()
               .Append(nameof(game.Type)).Append(_delimiter).Append(game.Type).AppendLine()
               .Append(nameof(game.Url)).Append(_delimiter).Append(game.Url);

        if (!string.IsNullOrEmpty(game.Description))
            builder.AppendLine().Append(nameof(game.Description)).Append(_delimiter).Append(game.Description);

        return builder.ToString();
    }
    
    #region UP Calc
    public static string DesiredUp(string fromInput, string toInput, string result, string multiplier, string currency)
    {
        StringBuilder builder = new();

        builder.Append(string.Format(Constants.GUI.Hints.DesiredUpPreText, fromInput, toInput)).AppendLine();
        builder.Append(_bulletin).Append(result).Append(' ').Append(currency).AppendLine();
        builder.Append(_bulletin).Append(string.Format(Constants.GUI.Hints.MultiplierToEnter, multiplier));

        return builder.ToString();
    }
    public static string ResourcesToSpend(string fromInput, string totalCostInput, string result, string multiplier, string currency)
    {
        StringBuilder builder = new();

        builder.Append(string.Format(Constants.GUI.Hints.ResourcesToSpendPreText, fromInput, totalCostInput, currency)).AppendLine();
        builder.Append(_bulletin).Append(result).Append(' ').Append(Constants.GUI.Labels.Up).Append('.').AppendLine();
        builder.Append(_bulletin).Append(string.Format(Constants.GUI.Hints.MultiplierToEnter, multiplier));

        return builder.ToString();
    }
    #endregion
    
    #region The Calc
    public static string AbleToBuy(string inputAmount, string currency, string resultAmount, Unit unit)
       => string.Format(Constants.GUI.Hints.YouCanBuy, resultAmount, unit.Name, inputAmount, currency);
    public static string CostToBuyOrSell(string inputAmount, string currency, string resultAmount, string operation, Unit unit)
        => string.Format(Constants.GUI.Hints.ItWouldCost, resultAmount, currency, operation, inputAmount, unit.Name);
    #endregion
}
