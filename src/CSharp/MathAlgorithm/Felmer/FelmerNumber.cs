using System;
using System.Numerics;

namespace MathAlgorithm.Felmer
{
    public static class FelmerNumber
    {
        /// <summary>
        /// Calculate felmer beyond n = 6
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static BigInteger CalcBigInteger(int n) => (BigInteger.Pow(2, (int)BigInteger.Pow(2, n)) + 1);

        /// <summary>
        /// Calculate felmer until n = 5
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static double CalcSmall(int n) => (Math.Pow(2, Math.Pow(2, n)) + 1);
    }
}