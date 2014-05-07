using System;

namespace Schemes.TimeDependent1D
{
    public class TimeDependent1DExactSolution
    {
        public TimeDependent1DExactSolution(Grid1D grid, double dt, Func<double, double, double> func, double tMax)
            : base(grid, dt)
        {
            Func = func;
            TMax = tMax;
        }

        public Func<double, double, double> Func { get; private set; }

        public double TMax { get; private set; }

        public void Fill()
        {     
            Next();
            while (tCurrent<TMax)
            {
                double[] layer = new double[Grid.N];
                for (int i = 0; i < Grid.N; i++)
                {
                    layer[i] = Func(Grid[i], tCurrent);
                }
                Next();
                AddLayer(layer);
            }
        }
    }
}