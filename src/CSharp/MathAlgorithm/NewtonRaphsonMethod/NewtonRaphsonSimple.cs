using System;

namespace MathAlgorithm.NewtonRaphsonMethod;

public class NewtonRaphsonSimple : INewtonRaphson
{
    public double Sqrt(double x)
    {
        double prev, z = 1.0;
        var i = 0;
        var init = false;
        const double threshold = 0.00000000001;
        while (true)
        {
            i++;
            prev = z;
            z -= (z * z - x) / (2 * z);
            if (z == prev || (init && Math.Abs(prev) < Math.Abs(z + threshold)))
            {
                break;
            }

            init = true;
        }

        Console.WriteLine($"input: {x}");
        Console.WriteLine($"count: {i}");
        return z;
    }
}
