using System.Globalization;
namespace Data.Commands;
public static class Convert
{   
    public static string ToLabel(long? value) => (value != null) ? value?.ToString("N0", CultureInfo.InvariantCulture)! : string.Empty;
    public static long ToNumber(string input)
    {
        if (string.IsNullOrEmpty(input))
            return default;

        bool parsed = long.TryParse(input, out long result);
        return parsed ? result : default;
    }
}
