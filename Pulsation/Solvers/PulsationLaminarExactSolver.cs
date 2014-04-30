using System;
using MathExtensions;
using Pulsation.Models;
using Schemes.TimeDependent1D;

namespace Pulsation.Solvers
{
    public class PulsationLaminarExactSolver : IPulsationLaminarSolver
    {
        public PulsationLaminarExactSolver(PulsationLaminarPhysicalData physicalData)
        {
            PhysicalData = physicalData;
        }

        #region Properties
        public PulsationLaminarPhysicalData PhysicalData { get; set; }
        #endregion

        #region Methods
        public TimeDependent1DSolution Solve(PulsationLaminarCalculationData calculationData)
        {
            var solution = new TimeDependent1DExactSolution(calculationData.Grid, calculationData.dt,
                                                                                u, calculationData.TMax);
            solution.Fill();          
            return solution;
        } 
        #endregion

        #region Functions
        public double u1(double r, double t)
        {
            double s = PhysicalData.s;
            double Re = PhysicalData.Re;
            double beis = ExtMath.bei(s);
            double bers = ExtMath.ber(s);
            double bei2sber2s = beis * beis + bers * bers;
            double beirs = ExtMath.bei(r * s);
            double berrs = ExtMath.ber(r * s);
            double s2 = s*s;

            double C = Re*bers/(bei2sber2s*s2);
            double B = C*beis/bers;
            return B*(berrs*Math.Cos(s2*t) - beirs*Math.Sin(s2*t)) - C*(beirs*Math.Cos(s2*t) + berrs*Math.Sin(s2*t));
        }

        public double u(double r, double t)
        {
            double s = PhysicalData.s;
            double Re = PhysicalData.Re;
            double beis = ExtMath.bei(s);
            double bers = ExtMath.ber(s);
            double bei2sber2s = beis * beis + bers * bers;
            double beirs = ExtMath.bei(r * s);
            double berrs = ExtMath.ber(r * s);

            return Re / (s * s) *
                   ((1 - (beis * beirs + bers * berrs) / bei2sber2s) * Math.Sin(t) +
                    ((beis * berrs - bers * beirs) / bei2sber2s) * Math.Cos(t));
        }
        #endregion
    }
}