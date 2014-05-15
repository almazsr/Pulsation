using System;
using Calculation.Classes;
using Calculation.Enums;

namespace Pulsation.Models
{
    public class PulsationLaminarPhysicalData
    {
        #region Constructors
        public PulsationLaminarPhysicalData(double Re = DefaultRe, double s = Defaults)
        {
            this.s = s;
            this.Re = Re;
            BoundaryConditions = new[]
                                         {
                                             new BoundaryCondition(t => 0, BoundaryConditionLocation.Left,
                                                                   BoundaryConditionType.Neumann),
                                             new BoundaryCondition(t => 0, BoundaryConditionLocation.Right,
                                                                   BoundaryConditionType.Dirichlet)
                                         };
        }
        #endregion

        public double F(double r, double t)
        {
            double s2 = s*s;
            return Re / s2 * Math.Cos(t);
        }

        public BoundaryCondition[] BoundaryConditions { get; private set; }

        #region Constants
        public const double Defaults = 2.849;
        public const double DefaultRe = 1;
        #endregion

        #region Properties        

        public double s { get; set; } 
        public double Re { get; set; } 
        #endregion 
    }
}