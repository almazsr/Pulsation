using System;
using Schemes.TimeDependent1D;

namespace Schemes.Classes.Schemes
{
    /// <summary>
    /// dU/dt=a^2*d^2U/dx^2+F(r,t)
    /// </summary>
    public class DiffusionDecartScheme : DiffusionScheme
    {                
        public DiffusionDecartScheme(double tMax, Func<double, double, double> fFunc, double a) : base(tMax, fFunc, a)
        {

        }

        public DiffusionDecartScheme(double tMax)
            : base(tMax)
        {

        }

        protected override void SolveInArea(TimeDependent1DSolution solution, TriDiagMatrix matrix)
        {
            double[] Un = solution.CurrentLayer;
            for (int i = 1; i < matrix.N - 1; i++)
            {
                double x = solution.Grid[i];
                double dx = solution.Grid.h;
                double dt = solution.dt;
                double t = solution.tCurrent;
                double a2 = a*a;
                matrix.A[i] = -a2*dt / (dx * dx);
                matrix.C[i] = 1 + 2 * a2 * dt / (dx * dx);
                matrix.B[i] = -a2 * dt / (dx * dx);
                matrix.F[i] = Un[i] + dt * FFunc(x, t);
            }
        }
    }
}