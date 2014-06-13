using System;
using Calculation.Classes;
using Calculation.Classes.Algorithms;
using Calculation.Classes.Algorithms.Common;
using Calculation.Classes.Algorithms.TimeDependent.Continues;
using Calculation.Classes.Algorithms.TimeDependent.Schemes;
using Calculation.Enums;
using Calculation.Helpers;
using Calculation.Interfaces;
using Pulsation.Models;

namespace Pulsation.Solvers
{   
    public static class PulsationSolver
    {
        public static void Solve(PulsationModel model)
        {
            PulsationData data = new PulsationData(model);

            IContinue timeMaxContinue = new TimeMaxContinue(data.TimeMax);
            IContinue calculationTimeoutContinue = new CalculationTimeoutContinue();
            IContinue periodicConvergenceContinue = new ConvergencePeriodicContinue();

            PulsationSchemeSolver pulsationSchemeSolver = new PulsationSchemeSolver();
            PulsationLaminarExactSolver pulsationLaminarExactSolver = new PulsationLaminarExactSolver();

            double H1 = data.H1;
            double H2 = data.H2;
            double H3 = data.H3;
            double s = data.s;
            double Re = data.Re;
            double epsilon = data.epsilon;
            double beta = data.beta;

            if (!model.IsComplexMode)
            {
                H1 = s * s;
                H2 = Re * beta * beta;
                H3 = epsilon * Re;
            }

            Func<double, double, double> f = (r, t) => PulsationSolver.f(H2, H3, r, t);
            Func<double, double, double> u = (r, t) => PulsationSolver.u(Re, s, r, t);
            double a = 1 / Math.Sqrt(H1);
            var leftBoundaryCondition = new BoundaryCondition(BoundaryConditionLocation.Left,
                                                               BoundaryConditionType.Neumann);
            var rightBoundaryCondition = new BoundaryCondition(BoundaryConditionLocation.Right,
                                                               BoundaryConditionType.Dirichlet);
            double[] initial = new double[data.GridN];
            if (model.Exact)
            {
                data.FlowMode = "Ламинарный";
                data.SolverType = typeof(PulsationLaminarExactSolver).Name;
                pulsationLaminarExactSolver.Solve("Пульсирующее ламинарное течение в трубе: точное решение", data,
                                                  u, timeMaxContinue);
            }
            if (model.Implicit)
            {
                data.FlowMode = "Ламинарный";
                data.SolverType = typeof(PulsationSchemeSolver).Name;
                data.SchemeType = typeof(DiffusionImplicitCylindricScheme1D).Name;
                pulsationSchemeSolver.Solve(
                    "Пульсирующее ламинарное течение в трубе: численное решение с помощью неявной схемы", data,
                    new DiffusionImplicitCylindricScheme1D(a, f), initial, leftBoundaryCondition, rightBoundaryCondition, timeMaxContinue);
            }
            if (model.CrankNikolson)
            {
                data.FlowMode = "Ламинарный";
                data.SolverType = typeof(PulsationSchemeSolver).Name;
                data.SchemeType = typeof(DiffusionCrankNicolsonCylindricScheme1D).Name;
                pulsationSchemeSolver.Solve(
                    "Пульсирующее ламинарное течение в трубе: численное решение с помощью схемы Кранка Никольсона", data,
                    new DiffusionCrankNicolsonCylindricScheme1D(a, f), initial, leftBoundaryCondition, rightBoundaryCondition, timeMaxContinue, periodicConvergenceContinue);
            }
            if (model.Explicit)
            {
                data.FlowMode = "Ламинарный";
                data.SolverType = typeof(PulsationSchemeSolver).Name;
                data.SchemeType = typeof(DiffusionExplicitScheme1D).Name;
                pulsationSchemeSolver.Solve(
                    "Пульсирующее ламинарное течение в трубе: численное решение с помощью явной схемы", data,
                    new DiffusionExplicitScheme1D(a, f), initial, leftBoundaryCondition, rightBoundaryCondition, timeMaxContinue);
            }
            if (model.Turbulent)
            {
                data.FlowMode = "Турбулентный";
                data.SolverType = typeof(PulsationSchemeSolver).Name;
                data.SchemeType = typeof(DiffusionInhomogeneousImplicitCylindricScheme1D).Name;
                pulsationSchemeSolver.Solve(
                    "Пульсирующее турбулентное течение в трубе: численное решение с помощью неявной схемы", data,
                    new DiffusionInhomogeneousImplicitCylindricScheme1D(PulsationSolver.k, f), initial, leftBoundaryCondition, rightBoundaryCondition, timeMaxContinue, periodicConvergenceContinue);
            }
        }

        public static double u(double Re, double s, double r, double t)
        {
            double beis = SpecialFunctions.bei(s);
            double bers = SpecialFunctions.ber(s);
            double bei2sber2s = beis * beis + bers * bers;
            double beirs = SpecialFunctions.bei(r * s);
            double berrs = SpecialFunctions.ber(r * s);

            return Re / (s * s) *
                   ((1 - (beis * beirs + bers * berrs) / bei2sber2s) * Math.Sin(t) +
                    ((beis * berrs - bers * beirs) / bei2sber2s) * Math.Cos(t));
        }

        public static double f(double H2, double H3, double r, double t)
        {
            return H2* Math.Cos(t) + H3;
        }

        public static double f(double Re, double s, double beta, double r, double t)
        {
            return Re / (s * s) * (beta * Math.Cos(t) + 1);
        }

        public static double k(double r, double U, double dU)
        {
            return C * C * r * r * (1 - r) * Math.Abs(dU);
        }

        public const double C = 0.1;
    }
}