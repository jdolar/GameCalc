namespace Calculator.Calculators;
public sealed class Simple
{
    public static string Divide(string left, string right, bool format = false) => Operation.Calculate(Calculate.Divide, left, right, format);
    public static string Sum(string left, string right, bool format = false) => Operation.Calculate(Calculate.Sum, left, right, format);
    public static string Deduct(string left, string right, bool format = false) => Operation.Calculate(Calculate.Deduct, left, right, format);
    public static string Multiply(string left, string right, bool format = false) => Operation.Calculate(Calculate.Multiply, left, right, format);
}
