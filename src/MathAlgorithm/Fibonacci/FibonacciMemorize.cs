using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace MathAlgorithm.Fibonacci
{
    public class FibonacciMemorize : IFibonacci
    {
        /// <summary>
        /// O(n) : TL;DR; Cache
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public BigInteger Caltulate(int n)
        {
            // long only available until 92.
            return n < 92 ? MemorizeLong(n) : MemorizeBig(n);
        }
        private long MemorizeLong(int n)
        {
            long prev = 1;
            long fprev = 1;
            long tmp = 1;
            for (var i = 1; i < n; i++)
            {
                tmp = prev + fprev;
                prev = fprev;
                fprev = tmp;
            }
            return tmp;
        }
        private BigInteger MemorizeBig(int n)
        {
            BigInteger prev = 1;
            BigInteger fprev = 1;
            BigInteger tmp = 1;
            for (var i = 1; i < n; i++)
            {
                tmp = prev + fprev;
                prev = fprev;
                fprev = tmp;
            }
            return tmp;
        }
    }
}
