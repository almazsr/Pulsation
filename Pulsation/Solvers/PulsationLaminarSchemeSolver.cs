using System;
using System.IO;
using Pulsation.Models;
using Schemes.Classes;
using Schemes.Classes.Schemes;
using Schemes.Interfaces;
using Schemes.TimeDependent1D;

namespace Pulsation.Solvers
{
    internal abstract class PulsationLaminarSchemeSolver : PulsationLaminarSolver
    {
        protected PulsationLaminarSchemeSolver()
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

        public TimeDependent1DSolution Solution { get; private set; }

        public abstract Scheme1D Scheme { get; }

        public override void BeginSolve(TextWriter writer)
        {
            
        }
    }
}