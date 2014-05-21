using System;
using Calculation.Classes;
using Calculation.Classes.Schemes;
using Calculation.Enums;
using Calculation.Helpers;
using Calculation.Interfaces;
using Calculation.UI.Models;

namespace Calculation.UI.Solvers
{
    public static class PulsationLaminar
    {
        public static void SolveExact(ISolutionContext context, PulsationLaminarModel model)
        {
            double s = model.s;
            double Re = model.Re;
            double dt = Math.PI * model.dAngle / 180;
            var grid = context.CreateGrid(0, 1, model.NGrid);
            var solution = context.CreateExactTimeDependentSolution(grid, new {model.Re, model.s}, dt);
            IStopCondition stopCondition = new TimeLimitCondition(PulsationLaminarModel.TimeMax);            
            solution.FillExact((r, t) => u(s, Re, r, t), stopCondition);
        }

        public static void Solve(ISolutionContext context, PulsationLaminarModel model, IScheme1D scheme)
        {
            var grid = context.CreateGrid(0, 1, model.NGrid);
            double dt = Math.PI*model.dAngle/180;
            var solution = context.CreateNumericTimeDependentSolution(grid, new {model.Re, model.s}, dt,
                                                                      scheme.GetType());
            IStopCondition stopCondition = new TimeLimitCondition(PulsationLaminarModel.TimeMax);
            IBoundaryCondition leftBoundaryCondition = new BoundaryCondition(BoundaryConditionLocation.Left,
                                                                             BoundaryConditionType.Neumann);
            IBoundaryCondition rightBoundaryCondition = new BoundaryCondition(BoundaryConditionLocation.Right,
                                                                              BoundaryConditionType.Dirichlet);
            scheme.Solve(solution, leftBoundaryCondition, rightBoundaryCondition, stopCondition);
        }

        public static void SolveImplicit(ISolutionContext context, PulsationLaminarModel model)
        {
            double s = model.s;
            double Re = model.Re;
            Solve(context, model, new DiffusionImplicitCylindricScheme1D((r, t) => f(s, Re, r, t), 1/s));
        }

        public static void SolveCrankNikolson(ISolutionContext context, PulsationLaminarModel model)
        {
            double s = model.s;
            double Re = model.Re;
            Solve(context, model, new CrankNicolsonCylindricScheme1D((r, t) => f(s, Re, r, t), 1 / s));
        }

        public static double u(double s, double Re, double r, double t)
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

        public static double f(double s, double Re, double r, double t)
        {
            return Re/(s*s)*Math.Cos(t);
        }
    }
}