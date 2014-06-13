using System.Collections.Generic;
using System.Linq;
using Calculation.Interfaces;

namespace Calculation.Classes.Algorithms.Common.Integrators
{
    public class SimpsonIntegrator : IIntegrator
    {
        public double GetIntegral(IEnumerable<double> f, double h, int N)
        {
            double result = 0;
            var fArray = f as List<double> ?? f.ToList();
            for (int k = 1; k < N - 1; k += 2)
            {
                result += fArray[k - 1] + 4 * fArray[k] + fArray[k + 1];
            }
            result *= h / 3;
            return result;
        }
    }
}