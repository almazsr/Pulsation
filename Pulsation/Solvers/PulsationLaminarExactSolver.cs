using System;
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

        public double u(double r, double t)
        {
            double s = PhysicalData.s;
            double Re = PhysicalData.Re;
            double beis = SpecialFunctions.bei(s);
            double bers = SpecialFunctions.ber(s);
            double bei2sber2s = beis * beis + bers * bers;
            double beirs = SpecialFunctions.bei(r * s);
            double berrs = SpecialFunctions.ber(r * s);

            return Re / (s * s) *
                   ((1 - (beis * beirs + bers * berrs) / bei2sber2s) * Math.Sin(t) +
                    ((beis * berrs - bers * beirs) / bei2sber2s) * Math.Cos(t));
        }
        #endregion
    }
}