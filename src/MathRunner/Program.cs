using MathAlgorithm.Fibonacci;
using System;
using System.Linq;

namespace MathRunner
{
    class Program
    {
        static void Main(string[] args)
        {
            var fibSlow = new IFibonacci[] { new FibonacciRecursive() };
            var fibFast = new IFibonacci[] { new FibonacciMemorize(), new FibonacciRunSquare()};
            foreach (var item in Enumerable.Range(1, 100)
                .Concat(Enumerable.Range(100000, 2))
                .Concat(Enumerable.Range(400000, 2)))
            {
                if (item < 15)
                {
                    Run(fibSlow, item);
                }
                Run(fibFast, item);
            }
        }

        static void Run(IFibonacci[] fibs, int item)
        {
            foreach (var fib in fibs)
            {
                Console.WriteLine(fib.Caltulate(item));
            }
        }
    }
}
