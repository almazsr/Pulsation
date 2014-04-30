using System;

namespace Schemes.Classes.Schemes
{
    public abstract class DiffusionScheme : Scheme
    {
        public DiffusionScheme(double tMax, Func<double, double, double> fFunc, double a) : base(tMax)
        {
            FFunc = fFunc;
            this.a = a;
        }

        public DiffusionScheme(double tMax)
            : this(tMax, (r, t) => 0, 1)
        {

        }

        public double a { get; set; }

        public Func<double, double, double> FFunc { get; set; }
    }
}