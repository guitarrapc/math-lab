using System;
using System.Collections.Generic;
using System.Text;

namespace MathAlgorithm.Probability
{
    public class Probability
    {
        readonly double _probability;
        readonly double _dprobability;

        public Probability(double probability)
        {
            _probability = probability;
            _dprobability = (_probability - 1) / _probability;
        }

        public IEnumerable<double> CalcAtLeast1(int loop)
        {
            for (var i = 0; i < loop; i++)
            {
                yield return 1d - CalcAtLeast1Func(i);
            }
        }
        double CalcAtLeast1Func(int i) => Math.Pow(_dprobability, i + 1);

        public IEnumerable<double> CalcContinue1(int loop)
        {
            for (var i = 0; i < loop; i++)
            {
                yield return CalcContinue1Func(i);
            }
        }
        double CalcContinue1Func(int i) => Math.Pow(1d - _dprobability, i + 1);
    }

    public static class DoubleEx
    {
        public static double ToPercentage(this double value, int digit = 2)
        {
            return (long)(value * Math.Pow(10, digit + 2)) / Math.Pow(10, digit);
        }
    }
}
