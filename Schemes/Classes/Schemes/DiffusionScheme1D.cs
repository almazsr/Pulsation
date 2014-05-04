using System;
using System.Collections.Generic;

namespace Schemes.Classes.Schemes
{
    public abstract class DiffusionScheme1D : Scheme1D
    {
        protected DiffusionScheme1D(IList<BoundaryCondition> boundaryConditions, Func<double, double, double> fFunc, double a) : 
            base(boundaryConditions)
        {
            FFunc = fFunc;
            this.a = a;
        }

        protected DiffusionScheme1D(IList<BoundaryCondition> boundaryConditions)
            : this(boundaryConditions, (r, t) => 0, 1)
        {

        }

        public double a { get; set; }

        public Func<double, double, double> FFunc { get; set; }
    }
}