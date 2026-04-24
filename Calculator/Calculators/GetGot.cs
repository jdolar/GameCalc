namespace Calculator.Calculators;
public sealed class GetGot
{
    public string CostToBuy(long userInput, long costPerUnit, bool? format = null) => Operation.CalculateAndFormatOutput(Calculate.Multiply, userInput, costPerUnit, format);
    public string CostToReassign(long userInput, long? costPerUnitReassign, bool? format = null) => costPerUnitReassign.HasValue ? Operation.CalculateAndFormatOutput(Calculate.Divide, userInput, costPerUnitReassign, format) : string.Empty;
    public string AbleToBuy(long userInput, long costPerUnit, bool? format = null) => Operation.CalculateAndFormatOutput(Calculate.Divide, userInput, costPerUnit, format);
}
