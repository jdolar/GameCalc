namespace Calculator.Calculators;
public sealed class UnitProduction
{
    public (string, string, string, string) UpdateUpCosts(string fromInput, string totalCost) => Operation.CalculateAndFormatOutputAndInput(UpgradeCost, fromInput, totalCost, true);
    public (string, string, string, string) DesiredUpCosts(string fromInput, string toInput) => Operation.CalculateAndFormatOutputAndInput(DesiredCost, fromInput, toInput, true);
    private (long, long) DesiredCost(long fromInput, long toInput)
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
    private (long, long) UpgradeCost(long fromInput, long totalCost)
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
}
