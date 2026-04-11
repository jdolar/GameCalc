using Data.Models;
using System.Text;
namespace Data;
public static class Hints
{
    private const string _bulletin = "        * ";
    private const string _preSpace = "  ";
    private const string _tailingSpace = " ";
    private const int _spaceBetween = 10;

    #region Frame
    public static string CopyToClipBoard(string value)=>string.Format(Constants.GUI.Hints.CopyAmountToClipBoard, value);
    public static string PersonalLog(PersonalLog log)
    {
        StringBuilder sb = new();
        
        int entryCount = log.Entries.Count;
        for (int i = 0; i < entryCount; i++)
        {
            if (log.Entries[i].Type == Enums.PersonalLog.EntryType.Player)
                sb.Append(Constants.PersonalLog.PlayerStats);
            else if (log.Entries[i].Type == Enums.PersonalLog.EntryType.Alliance)
                sb.Append(Constants.PersonalLog.AllianceStats);

            sb.Append(log.Entries[i].Id);
            sb.Append('>');

            if (log.Entries[i].Type == Enums.PersonalLog.EntryType.Alliance)
                sb.Append(" [ ");

            sb.Append(log.Entries[i].Name);

            if (log.Entries[i].Type == Enums.PersonalLog.EntryType.Alliance)
                sb.Append(" ] ");

            sb.Append(Constants.PersonalLog.LogEnd);

            if (i != entryCount - 1)
                sb.AppendLine();
        }

        return  sb.ToString();
    }
    #endregion

    #region Frame ComboBox
    public static string User(User user, List<Race> races, Enums.Game.Type selectedGameType)
    {
        if (user == null)
            return "";

        string[] keys =
        [
            Constants.Users.Name,
            Constants.Users.RaceId,
            Constants.Users.Id,
            Constants.Users.RecruitmentId,
            Constants.Users.Ascension,
            Constants.Users.UnitProduction,
            Constants.Users.Covert,
            Constants.Users.AntiCovert,
            Constants.Users.MsWeapons,
            Constants.Users.MsShields,
            Constants.Users.MsFleets,
        ];

        List<(string Label, string Value)> fields = [];
        var accounts = user.Accounts.Where(x => x.GameType == selectedGameType).ToList();
        foreach (Account account in accounts)
        {
            List<(string Label, string Value)> accountFields = [.. keys
                .Select(property =>
                {

                    if (property == Constants.Users.RecruitmentId &&
                        account.Properties.TryGetValue(Constants.Users.RecruitmentId, out int timeTicks))
                    {
                        DateTime date = DateTimeOffset
                            .FromUnixTimeSeconds(timeTicks)
                            .LocalDateTime;

                        return (Label: Constants.Users.AccountCreated, Value: date.ToString("yyyy-MM-dd HH:mm"));
                    }

                    else if (property == Constants.Users.RaceId &&
                        account.Properties.TryGetValue(Constants.Users.RaceId, out int raceId))
                    {
                        return (Label: property, Value: races.Find(x => x.Id == raceId)?.Name ?? string.Empty);
                    }

                    return (
                        Label: property,
                        Value: account.Properties.TryGetValue(property, out int value)
                            ? value.ToString()
                            : string.Empty
                    );
                })
                .Where(f => !string.IsNullOrEmpty(f.Value))

                .Prepend((nameof(Enums.Game.Type), Enum.IsDefined(account.GameType) ? account.GameType.ToString() : string.Empty))
                .Prepend((nameof(account.Name), account.Name))];

            fields.AddRange(accountFields);
        }

        return DrawFields(fields);
    }
    public static string Game(Game? game)
    {
        if (game is null)
            return string.Format(Constants.GUI.Labels.NotAvailable, nameof(Game));

        List<(string Label, string Value)> fields = [];

        AddField(fields, nameof(game.Name), game.Name);
        AddField(fields, nameof(game.Type), game.Type.ToString());
        AddField(fields, nameof(game.Url), game.Url.ToString());
        AddField(fields, nameof(game.Description), game.Description);

        StringBuilder builder = new();

        int calculatorCount = game.Calculators.Count;
        for(int i = 0; i < calculatorCount; i++)
        {
            builder.Append(game.Calculators[i].ToString());
            if (i < calculatorCount - 1)
                builder.Append(", ");
        }
        
        AddField(fields, nameof(game.Calculators), builder.ToString());

        return DrawFields(fields);
    }
    public static string Race(Race? race)
    {
        if (race == null || race.Units.Count == 0)
            return string.Format(Constants.GUI.Labels.NotAvailable, nameof(Race));

        List<(string Label, string Value)> fields = [];

        AddField(fields, nameof(race.Name), race.Name);
        AddField(fields, nameof(race.Type), race.Type.ToString());
        AddField(fields, nameof(race.Evolution), race.Evolution.ToString());
        AddField(fields, nameof(race.Currency), race.Currency.Name);

        fields.AddRange(GroupUnits(race.Units));

        return DrawFields(fields);
    }
    #endregion

    #region GetGot ComboBox
    public static string Unit(Unit unit)
    {
        if (unit == null)
            return string.Format(Constants.GUI.Labels.NotAvailable, nameof(Unit));

        List<(string Label, string Value)> fields = [];

        AddField(fields, nameof(unit.Name), unit.Name);
        AddField(fields, nameof(unit.CostPerUnit), unit.CostPerUnit.ToString());
        AddField(fields, nameof(unit.CostPerUnitReassign), unit.Strength.ToString());
        AddField(fields, nameof(unit.Type), unit.Type.ToString());
        AddField(fields, nameof(unit.Purpose), unit.Purpose.ToString());
        AddField(fields, nameof(unit.Evolution), unit.Evolution.ToString());
        AddField(fields, nameof(unit.Slot), unit.Slot.ToString());

        return DrawFields(fields);
    } 
    public static string Units(List<Unit> units)
    {
        if (units == null || units.Count == 0)
            return string.Format(Constants.GUI.Labels.NotAvailable, nameof(Units));

        return DrawFields(GroupUnits(units));
    }  
    #endregion

    #region GetGot
    public static string AbleToBuy(string inputAmount, string currency, string resultAmount, Unit unit)
       => string.Format(Constants.GUI.Hints.YouCanBuy, resultAmount, unit.Name, inputAmount, currency);
    public static string CostToBuyOrSell(string inputAmount, string currency, string resultAmount, string operation, Unit unit)
        => string.Format(Constants.GUI.Hints.ItWouldCost, resultAmount, currency, operation, inputAmount, unit.Name);
    #endregion

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

    #region Private Helpers
    private static void AddUnits(List<(string Label, string Value)> fields, List<Unit> units)
    {
        foreach (Unit unit in units)
            AddField(fields, $"{_preSpace}{unit.Name}", $"{unit.CostPerUnit}/unit");
    }
    private static string DrawFields(List<(string Label, string Value)> fields, string? preSpace = _preSpace, string? tailingSpace = _tailingSpace, int? spaceBetween = null)
    {
        if (fields.Count == 0)
            return string.Empty;

        int labelWidth = fields.Max(f => f.Label.Length);
        int valueWidth = fields.Max(f => f.Value.Length);
        ;

        StringBuilder sb = new();
        sb.AppendLine();
        foreach (var (Label, Value) in fields)
            sb.AppendLine(preSpace + Label.PadRight(labelWidth + (spaceBetween ??= _spaceBetween)) + Value.PadLeft(valueWidth) + tailingSpace);

        return sb.ToString();
    }
    private static void AddField(List<(string Label, string Value)> fields, string? label, string? value)
    {
        if (!string.IsNullOrEmpty(label) && !string.IsNullOrEmpty(value))
            fields.Add((label, value));
    }
    private static void AddField(List<(string Label, string Value)> fields, string? label)
    {
        if (!string.IsNullOrEmpty(label))
            fields.Add((label, string.Empty));
    }
    private static List<(string Label, string Value)> GroupUnits(List<Unit> units)
    {
        var groups = units.GroupBy(u => u.Type)
                          .OrderBy(g => g.Key);

        List<(string Label, string Value)> fields = [];
        foreach (var group in groups)
        {
            var sortedUnits = group.GroupBy(u => u.Purpose)
                                   .OrderBy(g => g.Key);
            
            foreach (var purposeGroup in sortedUnits)
            {
                AddField(fields, $"{purposeGroup.Key} {group.Key}(s)");
                AddUnits(fields, [.. purposeGroup]);
            }
        }

        return fields;
    }
    #endregion
}
