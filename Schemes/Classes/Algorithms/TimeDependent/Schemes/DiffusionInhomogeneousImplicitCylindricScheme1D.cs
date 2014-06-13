using System;
using Calculation.Classes.Algorithms.Common.Matrixes;
using Calculation.Helpers;

namespace Calculation.Classes.Algorithms.TimeDependent.Schemes
{
    public class DiffusionInhomogeneousImplicitCylindricScheme1D : DiffusionInhomogeneousScheme1D
    {
        public DiffusionInhomogeneousImplicitCylindricScheme1D(Func<double, double, double, double> kFunc, Func<double, double, double> fFunc) : base(kFunc, fFunc)
        {
        }

        public override void FillMatrix(TriDiagMatrix matrix, SequenceBundle bundle, Grid grid, double t, double dt)
        {
            var Un = bundle.CurrentLayer;
            for (int i = 1; i < matrix.N - 1; i++)
            {
                double ri = grid[i];
                double rim1 = grid[i - 1];
                double rip1 = grid[i + 1];
                double Ui = Un[i];
                double Uip1 = Un[i + 1];
                double Uim1 = Un[i - 1];
                double dr = grid.h;

                double ki = KFunc(ri, Ui, (Ui - Uim1) / dr);
                double kip1 = KFunc(rip1, Ui, (Uip1 - Ui) / dr);

                //matrix.A[i] =-dt/(dr*dr*ri)*(ki*ri);//-ki * dt / dr * (1 / dr - 1 / (2 * ri)-(ki-kim1)/dr);
                //matrix.C[i] = 1 + dt / (dr * dr * ri) * (kip1 * rip1 + ki * ri);//1 + ki * 2 * dt / (dr * dr);
                //matrix.B[i] = -dt / (dr * dr * ri) * (kip1 * rip1);
                //matrix.F[i] = Un[i] + dt * FFunc(ri, t);
                matrix.A[i] = -dt / (dr * dr) + dt / (ri * dr) * (1 - (ri * ki) / dr);
                matrix.C[i] = 1 + 2 * dt / (dr * dr) + dt / (ri * dr * dr) * (rip1 * kip1 + ri * ki);
                matrix.B[i] = -dt / (dr * dr) + dt / (ri * dr) * (-1 - (rip1 * kip1) / dr);
                matrix.F[i] = Un[i] + dt * FFunc(ri, t);
            }
        }
    }
}