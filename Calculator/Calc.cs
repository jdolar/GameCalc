using Data.Commands;
namespace Calculator;
public static class Calc
{
    #region PUBLIC Basic Operations
    public static string Divide(string left, string right, bool format = false) => Calculate(Operations.Divide, left, right, format);
    public static string Sum(string left, string right, bool format = false) => Calculate(Operations.Sum, left, right, format);
    public static string Deduct(string left, string right, bool format = false) => Calculate(Operations.Deduct, left, right, format);
    public static string Multiply(string left, string right, bool format = false) => Calculate(Operations.Multiply, left, right, format);
    public static long Multiply(long left, long right) => Operations.Multiply(left, right);
    #endregion

    #region PUBLIC BL Operations
    public static (string, string, string, string) CalculatePossibleUpUpgrade(string fromInput, string totalCost) => CalculateTuple(CalculatePossibleUpUpgradeCost, fromInput, totalCost, true);
    public static (string, string, string, string) CalculateDesiredUp(string fromInput, string toInput) => CalculateTuple(CalculateDesiredUpCost, fromInput, toInput, true);
    public static (string, string, string, string) CalculateAbleToBuyAndCostToBuy(string userInput, long costPerUnit, long? costPerUnitReassign, bool? format = null)
    {
        long input = Data.Commands.Convert.ToNumber(Clean.Text(userInput));
        string costToBuy = CalculateAndReturn(Operations.Multiply, input, costPerUnit, format);
        string ableToBuy = CalculateAndReturn(Operations.Divide, input, costPerUnit, format);
        string costToReassign = costPerUnitReassign.HasValue ? CalculateAndReturn(Operations.Divide, input, costPerUnit, format) : string.Empty;

        return (costToBuy, ableToBuy, costToReassign, Data.Commands.Convert.ToLabel(input));
    }
    #endregion

    #region PRIVATE Methods
    private static string Calculate(Func<long, long, long> action, string? left, string? right, bool? format = null)
    {
        if (string.IsNullOrEmpty(left) || string.IsNullOrEmpty(right))
            return string.Empty;
        
        long rightValue = Data.Commands.Convert.ToNumber(Clean.Text(right));
        long leftValue = Data.Commands.Convert.ToNumber(Clean.Text(left));
        
        return CalculateAndReturn(action, leftValue, rightValue, format);
    }
    private static string CalculateAndReturn(Func<long, long, long> action, long? left, long? right, bool? format = null)
    {
        if (left is null || right is null)
            return string.Empty;       
 
        long result = action((long)left, (long)right);

        return FormatResult(result, format);
    }
    private static (string, string, string, string) CalculateTuple(Func<long, long, (long, long)> action, string? left, string? right, bool? format = null)
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
    private static (long, long) CalculateDesiredUpCost(long fromInput, long toInput)
    {
        if (toInput <= fromInput)
            return (0, 0);

        long multiplier = (toInput - fromInput) / 3;

        const long k = 5_000L;
        const long baseStepCost = 10_000L;

        long arithmeticSum =
            multiplier * fromInput +
            3 * multiplier * (multiplier - 1) / 2;

        long totalCost =
            k * arithmeticSum +
            baseStepCost * multiplier;

        return (totalCost, multiplier);
    }
    private static (long, long) CalculatePossibleUpUpgradeCost(long fromInput, long totalCost)
    {
        if (totalCost <= 0)
            return (fromInput, 0);

        const long k = 5_000L;
        const long baseStepCost = 10_000L;

        // A m² + B m - totalCost = 0
        double A = 3.0 * k / 2.0;
        double B = k * fromInput - (3.0 * k / 2.0) + baseStepCost;

        double discriminant = B * B + 4.0 * A * totalCost;

        if (discriminant < 0)
            return (fromInput, 0);

        double sqrt = Math.Sqrt(discriminant);

        // positive root
        long m = (long)((-B + sqrt) / (2.0 * A));

        if (m < 0)
            m = 0;

        long toInput = fromInput + 3 * m;

        return (toInput, m);
    }
    #endregion
}