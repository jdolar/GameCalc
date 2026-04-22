using Data.Commands;
namespace Calculator;
public static class Operation
{
    public static long Multiply(long left, long right) => Calculator.Calculate.Multiply(left, right);
    public static string Calculate(Func<long, long, long> action, string? left, string? right, bool? format = null)
    {
        if (string.IsNullOrEmpty(left) || string.IsNullOrEmpty(right))
            return string.Empty;

        long rightValue = Data.Commands.Convert.ToNumber(Clean.Text(right));
        long leftValue = Data.Commands.Convert.ToNumber(Clean.Text(left));

        return CalculateAndFormatOutput(action, leftValue, rightValue, format);
    }
    public static string CalculateAndFormatOutput(Func<long, long, long> action, long? left, long? right, bool? format = null)
    {
        if (left is null || right is null)
            return string.Empty;

        long result = action((long)left, (long)right);

        return FormatResult(result, format);
    }
    public static (string, string, string, string) CalculateAndFormatOutputAndInput(Func<long, long, (long, long)> action, string? left, string? right, bool? format = null)
    {
        if (string.IsNullOrEmpty(left) || string.IsNullOrEmpty(right))
            return (string.Empty, string.Empty, string.Empty, string.Empty);

        long leftValue = Data.Commands.Convert.ToNumber(Clean.Text(left));
        long rightValue = Data.Commands.Convert.ToNumber(Clean.Text(right));
        (long results, long multiplier) = action(leftValue, rightValue);

        return (FormatResult(results, format), FormatResult(multiplier, format), FormatResult(leftValue, format), FormatResult(rightValue, format));
    }
    private static string FormatResult(long result, bool? format = null)
    {
        return (format.HasValue && format.Value) ? Data.Commands.Convert.ToLabel(result) : result.ToString();
    }
}