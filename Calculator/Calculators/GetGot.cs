using Data.Commands;
namespace Calculator.Calculators;
public sealed class GetGot
{
    public (string, string, string, string) Calculate(string userInput, long costPerUnit, long? costPerUnitReassign, bool? format = null)
    {
        long input = Data.Commands.Convert.ToNumber(Clean.Text(userInput));
        string costToBuy = Operation.CalculateAndFormatOutput(Calculator.Calculate.Multiply, input, costPerUnit, format);
        string ableToBuy = Operation.CalculateAndFormatOutput(Calculator.Calculate.Divide, input, costPerUnit, format);
        string costToReassign = costPerUnitReassign.HasValue ? Operation.CalculateAndFormatOutput(Calculator.Calculate.Divide, input, costPerUnitReassign, format) : string.Empty;

        return (costToBuy, ableToBuy, costToReassign, Data.Commands.Convert.ToLabel(input));
    }
    public  string CostToBuy(long userInput, long costPerUnit, bool? format = null) => Operation.CalculateAndFormatOutput(Calculator.Calculate.Multiply, userInput, costPerUnit, format);
    public string CostToReassign(long userInput, long? costPerUnitReassign, bool? format = null) => costPerUnitReassign.HasValue ? Operation.CalculateAndFormatOutput(Calculator.Calculate.Divide, userInput, costPerUnitReassign, format) : string.Empty;
    public string AbleToBuy(long userInput, long costPerUnit, bool? format = null) => Operation.CalculateAndFormatOutput(Calculator.Calculate.Divide, userInput, costPerUnit, format);
}
