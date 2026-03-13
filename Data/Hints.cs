using Data.Models;
using System.Text;
namespace Data;
public static class Hints
{
    private const string _delimeter = ": ";
    private const string _buletin = "        * ";
    private const string _line = "-----";
    private const string _space = "           ";
    public static string Unit(Unit unit)
    {
        StringBuilder builder = new(128);

        builder.Append(Constants.GUI.Hints.CostPerUnit).Append(_delimeter).Append(unit.CostPerUnit).AppendLine();

        if (unit.CostPerUnitReassign is int reassign)
            builder.Append(Constants.GUI.Hints.CostPerUnitReassign).Append(_delimeter).Append(reassign).AppendLine();

        if (unit.Strenght is int strength)
            builder.Append(Constants.GUI.Hints.Strenght).Append(_delimeter).Append(strength).AppendLine();

        builder.Append(Constants.GUI.Hints.Type).Append(_delimeter).Append(unit.Type).AppendLine();
        builder.Append(Constants.GUI.Hints.Purpose).Append(_delimeter).Append(unit.Purpose).AppendLine();

        if (unit.Slot is int slot)
            builder.Append(Constants.GUI.Hints.Slot).Append(_delimeter).Append(slot).AppendLine();

        return builder.ToString();
    }
    public static string Race(Race? race)
    {
        if (race == null || race.Units.Count == 0)
            return string.Format(Constants.GUI.Labels.NotAvailable, "Race");

        StringBuilder builder = new();
        builder.Append(race.Name).AppendLine();
        builder.Append(nameof(race.Type)).Append(_delimeter).Append(race.Type).AppendLine();
        builder.Append(nameof(race.Evolution)).Append(_delimeter).Append(race.Evolution).AppendLine();
        builder.Append(nameof(race.Currency)).Append(_delimeter).Append(race.Currency.Name).AppendLine();
        builder.AppendLine(Units(race.Units));

        return builder.ToString();
    }
    public static string Units(List<Unit> units)
    {
        if (units == null || units.Count == 0)
            return string.Format(Constants.GUI.Labels.NotAvailable, "Units");

        var groups = units.GroupBy(u => u.Type).OrderByDescending(g => g.Key);

        StringBuilder builder = new();
        foreach (var group in groups)
        {
            var sortedUnits = group.GroupBy(u => u.Purpose).OrderByDescending(g => g.Key);
            builder.Append(_line).Append(' ').Append(group.Key.ToString()).Append(' ').Append("(s)").AppendLine();
            foreach (var sortedUnit in sortedUnits)
            {
                builder.Append(_space).Append(sortedUnit.Key).Append(' ').Append(group.Key.ToString()).Append("(s)").AppendLine();
                foreach (var unit in sortedUnit)
                {
                    builder.Append(_space).Append(_space).Append(unit.ToLabel()).AppendLine();
                }
            }
        }

        return builder.ToString();
    }
    public static string Game(Game? game)
    {
        if (game is null)
            return string.Format(Constants.GUI.Labels.NotAvailable, "Game");

        StringBuilder builder = new();

        builder.Append(nameof(game.Name)).Append(_delimeter).Append(game.Name).AppendLine()
               .Append(nameof(game.Type)).Append(_delimeter).Append(game.Type).AppendLine()
               .Append(nameof(game.Url)).Append(_delimeter).Append(game.Url);

        if (!string.IsNullOrEmpty(game.Description))
            builder.AppendLine().Append(nameof(game.Description)).Append(_delimeter).Append(game.Description);

        return builder.ToString();
    }
    
    #region UP Calc
    public static string DesiredUp(string fromInput, string toInput, string result, string multiplier, string currency)
    {
        StringBuilder builder = new();

        builder.Append(string.Format(Constants.GUI.Hints.DesiredUpPreText, fromInput, toInput)).AppendLine();
        builder.Append(_buletin).Append(result).Append(' ').Append(currency).AppendLine();
        builder.Append(_buletin).Append(string.Format(Constants.GUI.Hints.MultiplierToEnter, multiplier));

        return builder.ToString();
    }
    public static string ResurcesToSpend(string fromInput, string totalCostInput, string result, string multiplier, string currency)
    {
        StringBuilder builder = new();

        builder.Append(string.Format(Constants.GUI.Hints.ResourcesToSpendPreText, fromInput, totalCostInput, currency)).AppendLine();
        builder.Append(_buletin).Append(result).Append(' ').Append(Constants.GUI.Labels.Up).Append('.').AppendLine();
        builder.Append(_buletin).Append(string.Format(Constants.GUI.Hints.MultiplierToEnter, multiplier));

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
