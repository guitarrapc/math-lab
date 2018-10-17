using MathAlgorithm.Fibonacci;
using MathAlgorithm.NewtonRaphsonMethod;
using System;
using System.Linq;

namespace MathRunner
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            // Fibonacci
            Console.WriteLine("Fibonacci");
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

            // NewtonRaphsonMethod
            Console.WriteLine("NewtonRaphson");
            var newtonSimple = new INewtonRaphson[] { new NewtonRaphsonSimple() };
            foreach (var item in new[] { 4, 8, 16, 60, 100, 10000, 6700000 })
            {
                RunNewtonRaphsonMethod(newtonSimple, item);
            }
        }

        private static void RunFibonacci(IFibonacci[] fibs, int item)
        {
            foreach (var fib in fibs)
            {
                Console.WriteLine(fib.Caltulate(item));
            }
        }

        private static void RunNewtonRaphsonMethod(INewtonRaphson[] newtons, int value)
        {
            foreach (var newton in newtons)
            {
                var result = newton.Sqrt(value);
                var match = result == Math.Sqrt(value);
                Console.WriteLine($"try: {result} ({match})");
            }
        }
    }
}
