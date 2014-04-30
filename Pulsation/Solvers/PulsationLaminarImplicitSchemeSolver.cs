using System;
using Pulsation.Models;
using Schemes.Classes;
using Schemes.Classes.Schemes;
using Schemes.Enums;
using Schemes.TimeDependent1D;

namespace Pulsation.Solvers
{
    public class PulsationLaminarImplicitSchemeSolver : IPulsationLaminarSolver
    {
        public PulsationLaminarImplicitSchemeSolver(PulsationLaminarPhysicalData physicalData)
        {
            SolutionTimeout = new TimeSpan(0, 0, 0, 1);
            PhysicalData = physicalData;
        }

        public PulsationLaminarPhysicalData PhysicalData { get; set; }

        public TimeDependent1DSolution Solve(PulsationLaminarCalculationData calculationData)
        {
            return SolveCycle(calculationData);
        }

        public TimeDependent1DSolution SolveCycle(PulsationLaminarCalculationData calculationData)
        {
            double Re = PhysicalData.Re;
            double s = PhysicalData.s;
            double s2 = s*s;
            double dt = calculationData.dt;
            DiffusionCylindricScheme scheme = new DiffusionCylindricScheme(calculationData.TMax, fFunc: (r, t) => Re/s2*Math.Cos(t), a: 1/s);
            double[] u0 = new double[calculationData.Grid.N];
            var solution = scheme.Solve(calculationData.Grid, new[]
                                                   {
                                                       new BoundaryCondition(t => 0, BoundaryConditionLocation.Left,
                                                                             BoundaryConditionType.Neumann),
                                                       new BoundaryCondition(t => 0, BoundaryConditionLocation.Right,
                                                                             BoundaryConditionType.Dirichlet)
                                                   }, u0, dt);
            return solution;
        }

        public bool IsTimeout { get; set; }

        public TimeSpan SolutionTimeout { get; set; }

        public const double Epsilon = 1E-6;
    }
}