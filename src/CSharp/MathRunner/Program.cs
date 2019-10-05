using MathAlgorithm.Fibonacci;
using MathAlgorithm.NewtonRaphsonMethod;
using MathAlgorithm.Probability;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace MathRunner
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            // Fibonacci
            Console.WriteLine("## Fibonacci");
            var fibSlow = new IFibonacci[] { new FibonacciRecursive() };
            var fibFast = new IFibonacci[] { new FibonacciMemorize(), new FibonacciRunSquare() };
            foreach (var item in Enumerable.Range(1, 100)
                .Concat(Enumerable.Range(100000, 2))
                .Concat(Enumerable.Range(400000, 2)))
            {
                if (item < 15)
                {
                    RunFibonacci(fibSlow, item);
                }
                RunFibonacci(fibFast, item);
            }
            Console.WriteLine("-----------------------");

            // NewtonRaphsonMethod
            Console.WriteLine("## NewtonRaphson");
            var newtonSimple = new INewtonRaphson[] { new NewtonRaphsonSimple() };
            foreach (var item in new[] { 4, 8, 16, 60, 100, 10000, 6700000 })
            {
                RunNewtonRaphsonMethod(newtonSimple, item);
            }
            Console.WriteLine("-----------------------");

            // Probability
            Console.WriteLine("## Probability");
            RunProbabilityMethod();
        }

        private static void RunFibonacci(IFibonacci[] fibs, int item)
        {
            foreach (var fib in fibs)
            {
                Console.WriteLine("  " + fib.Caltulate(item));
            }
        }

        private static void RunNewtonRaphsonMethod(INewtonRaphson[] newtons, int value)
        {
            foreach (var newton in newtons)
            {
                var result = newton.Sqrt(value);
                var match = result == Math.Sqrt(value);
                Console.WriteLine($"  try: {result} ({match})");
            }
        }

        private static void RunProbabilityMethod()
        {
            // Percentage of 1/50 will selected at least once with 50 iteration.
            var source = new Probability(50).CalcAtLeast1(50).Select(x => x.ToPercentage(9));
            Console.WriteLine($"At least onetime for 1/50 in 50 itration: {source.Last()}");

            // Percentage of 1/6 will continuously selected for 7 iteration.
            var source2 = new Probability(6).CalcContinue1(7).Select(x => x.ToPercentage(8));
            Console.WriteLine($"Continuously get 1/6 in 7 itration: {source2.Last()}");

            // LinqPad Utility to show Chart
            //var i = 1;
            //Util.Chart(source, x => $"try:{i++}", x => x).Dump();
        }
    }
}
