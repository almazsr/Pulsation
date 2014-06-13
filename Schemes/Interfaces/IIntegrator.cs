using System.Collections.Generic;

namespace Calculation.Interfaces
{
    public interface IIntegrator
    {
        double GetIntegral(IEnumerable<double> f, double h, int N);
    }
}