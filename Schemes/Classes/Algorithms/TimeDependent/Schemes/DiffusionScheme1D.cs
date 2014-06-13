using System;
using Calculation.Classes.Algorithms.Common.Matrixes;
using Calculation.Helpers;
using Calculation.Interfaces;
using Array = Calculation.Classes.Data.Array;

namespace Calculation.Classes.Algorithms.TimeDependent.Schemes
{
    /// <summary>
    /// f(r, t)
    /// </summary>
    public abstract class DiffusionScheme1D : IScheme1D
    {
        protected DiffusionScheme1D(double a, Func<double, double, double> fFunc)
        {
            this.a = a;
            this.FFunc = fFunc;
        }

        public double a { get; set; }

        public Func<double, double, double> FFunc { get; set; }

        public abstract void FillMatrix(TriDiagMatrix matrix, SequenceBundle bundle, Grid grid, double t, double dt);
    }
}