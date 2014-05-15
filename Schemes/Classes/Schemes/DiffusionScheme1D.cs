using System;

namespace Calculation.Classes.Schemes
{
    public abstract class DiffusionScheme1D : Scheme1D
    {
        protected DiffusionScheme1D(Func<double, double, double> fFunc, double a)
        {
            FFunc = fFunc;
            this.a = a;
        }

        protected DiffusionScheme1D()
            : this((r, t) => 0, 1)
        {

        }

        public double a { get; set; }

        public Func<double, double, double> FFunc { get; set; }
    }
}