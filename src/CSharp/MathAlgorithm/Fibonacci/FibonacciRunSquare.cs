using System;
using System.Numerics;

namespace MathAlgorithm.Fibonacci;

public class FibonacciRunSquare : IFibonacci
{
    /// <summary>
    /// O(log n) : TL;DR; Matrix with repeated square calculation.
    /// </summary>
    /// <param name="n"></param>
    /// <returns></returns>
    public BigInteger Caltulate(int n)
    {
        // long only available until 92.
        if (n < 92)
        {
            var a = new long[,] { { 1, 1 }, { 1, 0 } };
            a = PowMatrix(a, n + 1);
            return a[1, 0];
        }
        else
        {
            var a = new BigInteger[,] { { 1, 1 }, { 1, 0 } };
            a = BigPowMatrix(a, n + 1);
            return a[1, 0];
        }
    }

    private long Digit(long num)
    {
        return (num == 0) ? 1 : ((long)Math.Log10(num) + 1);
    }

    private long[,] PowMatrix(long[,] a, long n)
    {
        // Initialize : Unit Matrix
        var result = new long[a.GetLength(0), a.GetLength(1)];
        for (var i = 0; i < a.GetLength(0); i++)
        {
            result[i, i] = 1;
        }

        //　Exponential Calulation
        var maxDigit = long.MaxValue;
        while (n > 0)
        {
            // Calculate required Digit
            var digit = Digit(a[1, 1]);
            digit = digit * 3 >= maxDigit ? maxDigit : digit * 3;

            // base check
            if ((n & 0x01) == 1)
            {
                result = MulMatrix(a, result, digit);
            }
            a = MulMatrix(a, a, digit);
            // Shift
            n >>= 1;
        }

        return result;
    }

    private long[,] MulMatrix(long[,] a, long[,] b, long d)
    {
        // matrix row x column
        // matrix length
        int ni = a.GetLength(0), nj = b.GetLength(1), nk = b.GetLength(0);
        // reverse matrix b
        var result = new long[ni, nj];

        // reverse matrix b
        var bt = new long[nj, nk];
        for (var i = 0; i < nk; i++)
        {
            for (var j = 0; j < nj; j++)
            {
                bt[i, j] = b[j, i];
            }
        }

        var sum = 0L;
        // column # of matrix a
        for (var i = 0; i < ni; i++)
        {
            // column # of matrix b
            for (var j = 0; j < nj; j++)
            {
                sum = 0;
                // row # of matrix b
                for (var k = 0; k < nk; k++)
                {
                    sum += a[i, k] * bt[j, k];
                }
                result[i, j] = sum;
            }
        }

        return result;
    }

    private BigInteger[,] BigPowMatrix(BigInteger[,] a, long n)
    {
        // Initialize : Unit Matrix
        var result = new BigInteger[a.GetLength(0), a.GetLength(1)];
        for (var i = 0; i < a.GetLength(0); i++)
        {
            result[i, i] = 1;
        }

        //　Exponential Calulation
        var maxDigit = int.MaxValue;
        while (n > 0)
        {
            // Calculate required Digit
            var digit = maxDigit;

            // base check
            if ((n & 0x01) == 1)
            {
                result = BigMulMatrix(a, result, digit);
            }
            a = BigMulMatrix(a, a, digit);
            // Shift
            n >>= 1;
        }

        return result;
    }

    private BigInteger[,] BigMulMatrix(BigInteger[,] a, BigInteger[,] b, BigInteger d)
    {
        // matrix row x column
        // matrix length
        int ni = a.GetLength(0), nj = b.GetLength(1), nk = b.GetLength(0);
        var result = new BigInteger[ni, nj];

        // reverse matrix b
        var bt = new BigInteger[nj, nk];
        for (var i = 0; i < nk; i++)
        {
            for (var j = 0; j < nj; j++)
            {
                bt[i, j] = b[j, i];
            }
        }

        BigInteger sum = 0;
        // column # of matrix a
        for (var i = 0; i < ni; i++)
        {
            // column # of matrix b
            for (var j = 0; j < nj; j++)
            {
                sum = 0;
                // row # of matrix b
                for (var k = 0; k < nk; k++)
                {
                    sum += a[i, k] * bt[j, k];
                }
                result[i, j] = sum;
            }
        }

        return result;
    }
}
