using System;
using Pulsation.Models;
using Schemes.Classes;
using Schemes.Interfaces;
using Schemes.TimeDependent1D;

namespace Pulsation.Solvers
{
    internal class PulsationLaminarSchemeSolver : IAsyncSolver<PulsationLaminarPhysicalData, PulsationLaminarCalculationData, TimeDependent1DSolution>
    {
        public PulsationLaminarSchemeSolver()
        {
            SolutionTimeout = new TimeSpan(0, 0, 0, DefaultSeconds);
        }

        public const int DefaultSeconds = 10;

        public TimeDependent1DSolution Solve(PulsationLaminarCalculationData calculationData, IScheme1D scheme)
        {
            return SolveCycle(calculationData, scheme);
        }

        protected TimeDependent1DSolution SolveCycle(PulsationLaminarCalculationData calculationData, IScheme1D scheme)
        {
            double dt = calculationData.dt;
            TimeLimitCondition timeLimitCondition = new TimeLimitCondition(calculationData.TMax);       
            double[] u0 = new double[calculationData.Grid.N];
            var solution = scheme.Solve(timeLimitCondition, calculationData.Grid, u0, dt);
            return solution;
        }

        public bool IsTimeout { get; set; }

        public TimeSpan SolutionTimeout { get; set; }

        public const double Epsilon = 1E-6;
        public void BeginSolve()
        {
            throw new NotImplementedException();
        }

        public PulsationLaminarPhysicalData PhysicalData { get; set; }
        public PulsationLaminarCalculationData CalculationData { get; set; }
        public TimeDependent1DSolution Solution { get; private set; }
        public event EventHandler Solved;
    }
}