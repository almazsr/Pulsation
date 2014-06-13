using System.Collections.Generic;
using System.Linq;
using Calculation.Interfaces;

namespace Calculation.Classes.Algorithms.Common.Integrators
{
    public class TrapezoidalIntegrator : IIntegrator
    {
        public double GetIntegral(double[] f, double h, int N)
        {
            double result = (f[0] + f[N - 1])/2;
            for (int k = 1; k < N - 1; k++)
            {
                result += f[k];
            }
            result *= h;
            return result;
        }

        public double GetIntegral(IEnumerable<double> f, double h, int N)
        {
            var fList = f as List<double> ?? f.ToList();
            double result = (fList[0] + fList[N - 1]) / 2;
            for (int k = 1; k < N - 1; k++)
            {
                result += fList[k];
            }
            result *= h;
            return result;
        }
    }
}