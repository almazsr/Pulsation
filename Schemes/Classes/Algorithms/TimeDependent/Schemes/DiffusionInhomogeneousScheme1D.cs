using System;
using Calculation.Classes.Algorithms.Common.Matrixes;
using Calculation.Helpers;
using Calculation.Interfaces;
using Array = Calculation.Classes.Data.Array;

namespace Calculation.Classes.Algorithms.TimeDependent.Schemes
{
    /// <summary>
    /// k(r, u, du/dr); f(r,t)
    /// </summary>
    public abstract class DiffusionInhomogeneousScheme1D : IScheme1D
    {
        protected DiffusionInhomogeneousScheme1D(Func<double, double, double, double> kFunc, Func<double, double, double> fFunc)
        {
            this.KFunc = kFunc;
            this.FFunc = fFunc;
        }

        public Func<double, double, double, double> KFunc { get; set; }

        public Func<double, double, double> FFunc { get; set; }

        public abstract void FillMatrix(TriDiagMatrix matrix, SequenceBundle bundle, Grid grid, double t, double dt);
    }
}