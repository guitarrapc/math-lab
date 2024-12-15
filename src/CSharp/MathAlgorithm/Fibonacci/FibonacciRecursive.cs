using System.Numerics;

namespace MathAlgorithm.Fibonacci;

public class FibonacciRecursive : IFibonacci
{
    /// <summary>
    /// O(n^2) : TL;DR; don't use this
    /// </summary>
    /// <param name="n"></param>
    /// <returns></returns>
    public BigInteger Caltulate(int n)
    {
        if (n <= 2) return n;
        return Caltulate(n - 1) + Caltulate(n - 2);
    }
}
