using Data.Models;
using System.Security.AccessControl;
using System.Text;
namespace Data;

public static class Hints
{
    private const string _delimiter = ": ";
    private const string _bulletin = "        * ";
    private const string _line = "-----";
    private const string _space = "           ";
    public static string User(User user, List<Race> races, string _space = "  ")
    {
        if (user == null)
            return "";

        var keys = new[]
        {
            Constants.Users.Race,
            Constants.Users.Id,
            Constants.Users.RecruitmentId,
            Constants.Users.Ascension,
            Constants.Users.UnitProduction,
            Constants.Users.Covert,
            Constants.Users.AntiCovert,
            Constants.Users.MsWeapons,
            Constants.Users.MsShields,
            Constants.Users.MsFleets,       
        };

        List<(string, string)> fields = [];
        fields.Add((nameof(user.Name), user.Name ?? string.Empty));

        foreach (var account in user.Accounts)
        {
            List<(string, string)> accountFields = keys
                .Select(property =>
                {
                    if (property == Constants.Users.RecruitmentId &&
                        account.Properties.TryGetValue(Constants.Users.RecruitmentId, out int ts))
                    {
                        DateTime date = DateTimeOffset
                            .FromUnixTimeSeconds(ts)
                            .LocalDateTime;

                        return (Label: Constants.Users.AccountCreated, Value: date.ToString("yyyy-MM-dd HH:mm"));
                    }

                    else if (property == Constants.Users.Race &&
                        account.Properties.TryGetValue(Constants.Users.Race, out int raceId))
                    {
                        Race? race = races.Find(x => x.Id == raceId);
                        return (Label: property, Value: race != null ? race.Name : string.Empty);
                    }

                    return (
                        Label: property,
                        Value: account.Properties.TryGetValue(property, out int v)
                            ? v.ToString()
                            : string.Empty
                    );
                })         
                .Where(f => !string.IsNullOrEmpty(f.Item2) && f.Item2 != "0")
                 .Prepend((nameof(Enums.Game.Type), Enum.IsDefined(typeof(Enums.Game.Type), account.GameType) ? account.GameType.ToString() : string.Empty))
                .Prepend((_line, _line))            
                .ToList();
            fields.AddRange(accountFields);
        }

        if (fields.Count == 0)
            return string.Empty;

        int labelWidth = fields.Max(f => f.Item1.Length);
        int valueWidth = fields.Max(f => f.Item2.Length);

        StringBuilder sb = new();

        foreach (var field in fields)
            sb.AppendLine(_space + field.Item1.PadRight(labelWidth + 2) + field.Item2.PadLeft(valueWidth));

        return sb.ToString();
    }
    public static string Unit(Unit unit, string _space = "  ")
    {
        if (unit == null)
            return "";

        var fields = new (string Label, string Value)[]
        {
            (nameof(unit.Name), unit.Name ?? string.Empty),
            (nameof(unit.CostPerUnit), unit.CostPerUnit.ToString()),
            (nameof(unit.CostPerUnitReassign), unit.CostPerUnitReassign?.ToString() ?? string.Empty),
            (nameof(unit.Strength), unit.Strength?.ToString() ?? string.Empty),
            (nameof(unit.Type), unit.Type.ToString()),
            (nameof(unit.Purpose), unit.Purpose.ToString()),
            (nameof(unit.Evolution), unit.Evolution.ToString()),
            (nameof(unit.Slot), unit.Slot?.ToString() ?? string.Empty)
        }
        .Where(f => !string.IsNullOrEmpty(f.Value))
        .ToArray();

        int labelWidth = fields.Max(f => f.Label.Length);
        int valueWidth = fields.Max(f => f.Value.Length);

        StringBuilder sb = new();
        foreach (var (Label, Value) in fields)
            sb.AppendLine(_space + Label.PadRight(labelWidth + 2) + Value.PadLeft(valueWidth));

        return sb.ToString();
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

            builder.Append(_line).Append(' ').Append(group.Key).Append("(s)").AppendLine();

            foreach (var purposeGroup in sortedUnits)
            {
                builder.Append(_space).Append(purposeGroup.Key).Append(' ').Append(group.Key).Append("(s)").AppendLine();
                builder.Append(UnitNameAndCost(purposeGroup.ToList(), maxNameLength, maxPriceLength));
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

    #region Private Helpers
    private static string UnitNameAndCost(List<Unit> units, int maxNameLength, int maxPriceLength)
    {
        StringBuilder builder = new();

        foreach (Unit unit in units)
        {
            string name = unit.Name ?? "";
            string price = $"{unit.CostPerUnit}/unit";

            builder.Append(_space)
                   .Append(_space)
                   .Append(name.PadRight(maxNameLength + 4))
                   .Append(price.PadLeft(maxPriceLength))
                   .AppendLine();
        }

        return builder.ToString();
    }

    #endregion
}
