namespace Calculator;
internal static class Operations
{
    internal static long Multiply(long left, long right) => left * right;
    internal static long Divide(long left, long right) => right != 0 ? left / right : 0;
    internal static long Sum(long left, long right) =>  left + right;
    internal static long Deduct(long left, long right) => left > right ? left - right : default;
}
