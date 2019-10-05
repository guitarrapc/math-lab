using System;
using System.Collections.Generic;
using System.Text;

namespace MathAlgorithm.Probability
{
    public static class ProbabilitySimple
    {
        public static double AtLeast1(double probability, int loop)
            => Math.Pow((probability - 1) / probability, loop);
        public static double Continue1(double probability, int loop)
            => Math.Pow(1d - (probability - 1) / probability, loop);
    }
}
