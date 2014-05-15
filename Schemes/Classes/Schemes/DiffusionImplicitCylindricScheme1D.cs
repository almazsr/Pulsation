using System;
using System.Collections.Generic;
using Calculation.Interfaces;

namespace Calculation.Classes.Schemes
{
    /// <summary>
    /// dU/dt=a^2*(d^2U/dr^2+1/r*dU/dr)+F(r,t)
    /// </summary>
    public class DiffusionImplicitCylindricScheme1D : DiffusionScheme1D
    {
        public DiffusionImplicitCylindricScheme1D(IList<BoundaryCondition> boundaryConditions, Func<double, double, double> fFunc, double a) : base(boundaryConditions, fFunc, a)
        {
        }

        public DiffusionImplicitCylindricScheme1D(IList<BoundaryCondition> boundaryConditions) : base(boundaryConditions)
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
                matrix.A[i] = -a2 * dt / dr * (1 / dr - 1 / (2 * r));
                matrix.C[i] = 1 + a2 * 2 * dt / (dr * dr);
                matrix.B[i] = -a2 * dt / dr * (1 / dr + 1 / (2 * r));
                matrix.F[i] = Un[i] + dt * FFunc(r, t);
            }
        }
    }
}