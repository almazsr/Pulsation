using System;
using Calculation.Classes.Algorithms.Common.Matrixes;
using Calculation.Helpers;

namespace Calculation.Classes.Algorithms.TimeDependent.Schemes
{
    /// <summary>
    /// dU/dt=a^2*(d^2U/dr^2+1/r*dU/dr)+F(r,t)
    /// </summary>
    public class DiffusionImplicitCylindricScheme1D : DiffusionScheme1D
    {
        public DiffusionImplicitCylindricScheme1D(double a, Func<double, double, double> fFunc) : base(a, fFunc)
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
                matrix.A[i] = -a2 * dt / dr * (1 / dr - 1 / (2 * r));
                matrix.C[i] = 1 + a2 * 2 * dt / (dr * dr);
                matrix.B[i] = -a2 * dt / dr * (1 / dr + 1 / (2 * r));
                matrix.F[i] = Un[i] + dt * FFunc(r, t);
            }
        }
    }
}