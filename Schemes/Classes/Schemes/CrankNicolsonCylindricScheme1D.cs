using System;
using System.Collections.Generic;
using Calculation.Interfaces;

namespace Calculation.Classes.Schemes
{
    public class CrankNicolsonCylindricScheme1D : DiffusionScheme1D
    {
        public CrankNicolsonCylindricScheme1D(IList<BoundaryCondition> boundaryConditions, Func<double, double, double> fFunc, double a) : base(boundaryConditions, fFunc, a)
        {
        }

        public CrankNicolsonCylindricScheme1D(IList<BoundaryCondition> boundaryConditions) : base(boundaryConditions)
        {
        }       

        protected internal override void FillMatrix(TriDiagMatrix matrix, ILayer1D currentLayer, IGrid1D grid, double t, double dt)
        {
            var Un = currentLayer;
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