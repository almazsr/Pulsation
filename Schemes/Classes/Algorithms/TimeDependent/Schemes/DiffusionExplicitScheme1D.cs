using System;
using Calculation.Classes.Algorithms.Common.Matrixes;
using Calculation.Helpers;

namespace Calculation.Classes.Algorithms.TimeDependent.Schemes
{
    public class DiffusionExplicitScheme1D : DiffusionScheme1D
    {
        public DiffusionExplicitScheme1D(double a, Func<double, double, double> fFunc) : base(a, fFunc)
        {
        }

        public override void FillMatrix(TriDiagMatrix matrix, SequenceBundle bundle, Grid grid, double t, double dt)
        {
            var Un = bundle.CurrentLayer;
            for (int i = 1; i < matrix.N - 1; i++)
            {
                double r = grid[i];
                double dr = grid.h;
                double a2 = a * a;
                matrix.F[i] = Un[i - 1]*(a2*dt/dr*(1/dr - 1/(2*r))) + Un[i]*(1 - a2*2*dt/(dr*dr)) +
                              Un[i + 1]*(a2*dt/dr*(1/dr + 1/(2*r))) + dt*FFunc(r, t);
                matrix.C[i] = 1;
            }
        }
    }
}