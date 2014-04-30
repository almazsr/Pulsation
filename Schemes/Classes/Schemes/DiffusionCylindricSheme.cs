using System;
using Schemes.TimeDependent1D;

namespace Schemes.Classes.Schemes
{
    /// <summary>
    /// dU/dt=a^2*(d^2U/dr^2+1/r*dU/dr)+F(r,t)
    /// </summary>
    public class DiffusionCylindricScheme : DiffusionScheme
    {        
        public DiffusionCylindricScheme(double tMax, Func<double, double, double> fFunc, double a) : base(tMax, fFunc, a)
        {

        }

        public DiffusionCylindricScheme(double tMax)
            : base(tMax)
        {

        }

        protected override void SolveInArea(TimeDependent1DSolution solution, TriDiagMatrix matrix)
        {
            double[] Un = solution.CurrentLayer;
            for (int i = 1; i < matrix.N - 1; i++)
            {
                double r = solution.Grid[i];
                double dr = solution.Grid.h;
                double dt = solution.dt;
                double t = solution.tCurrent;
                double a2 = a*a;
                matrix.A[i] = -a2*dt/dr*(1/dr - 1/(2*r));
                matrix.C[i] = 1 + a2*2*dt/(dr*dr);
                matrix.B[i] = -a2*dt/dr*(1/dr + 1/(2*r));
                matrix.F[i] = Un[i] + dt*FFunc(r, t);
            }
        }
    }
}