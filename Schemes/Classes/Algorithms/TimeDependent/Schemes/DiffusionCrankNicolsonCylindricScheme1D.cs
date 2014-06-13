using System;
using Calculation.Classes.Algorithms.Common.Matrixes;
using Calculation.Helpers;
using Array = Calculation.Classes.Data.Array;

namespace Calculation.Classes.Algorithms.TimeDependent.Schemes
{
    public class DiffusionCrankNicolsonCylindricScheme1D : DiffusionScheme1D
    {
        public DiffusionCrankNicolsonCylindricScheme1D(double a, Func<double, double, double> fFunc) : base(a, fFunc)
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
                matrix.A[i] = -a2 * (dt / 2) / dr * (1 / dr - 1 / (2 * r));
                matrix.C[i] = 1 + a2 * dt / (dr * dr);
                matrix.B[i] = -a2 * (dt / 2) / dr * (1 / dr + 1 / (2 * r));
                matrix.F[i] = Un[i] + dt / 2 * (FFunc(r, t) + FFunc(r, t - dt)) +
                              a2 * (dt / 2) * ((Un[i + 1] - 2 * Un[i] + Un[i - 1]) / (dr * dr) + 1 / r * (Un[i + 1] - Un[i - 1]) / (2 * dr));
            }
        }
    }
}