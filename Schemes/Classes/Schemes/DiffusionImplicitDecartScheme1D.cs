using System;
using System.Collections.Generic;
using Calculation.Interfaces;

namespace Calculation.Classes.Schemes
{
    /// <summary>
    /// dU/dt=a^2*d^2U/dx^2+F(r,t)
    /// </summary>
    public class DiffusionImplicitDecartScheme1D : DiffusionScheme1D
    {
        public DiffusionImplicitDecartScheme1D(Func<double, double, double> fFunc, double a) : base(fFunc, a)
        {
        }

        protected internal override void FillMatrix(TriDiagMatrix matrix, ILayer1D currentLayer, IGrid1D grid, double t, double dt)
        {
            var Un = currentLayer;
            for (int i = 1; i < matrix.N - 1; i++)
            {
                double x = grid[i];
                double dx = grid.h;
                double a2 = a * a;
                matrix.A[i] = -a2 * dt / (dx * dx);
                matrix.C[i] = 1 + 2 * a2 * dt / (dx * dx);
                matrix.B[i] = -a2 * dt / (dx * dx);
                matrix.F[i] = Un[i] + dt * FFunc(x, t);
            }
        }
    }
}