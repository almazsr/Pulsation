using System;
using System.Data.Entity;
using Calculation.Classes;
using Calculation.Classes.Schemes;
using Calculation.Database;
using Calculation.Enums;
using Calculation.Helpers;
using Calculation.Interfaces;
using Calculation.UI.Models;

namespace Calculation.UI.Solvers
{
    public class PulsationLaminarSolver
    {
        public PulsationLaminarSolver(PulsationLaminarModel model)
        {
            this.s = model.s;
            this.Re = model.Re;
            this.dt = Math.PI * model.dAngle / 180;
            this.NGrid = model.NGrid;
        }

        public double s { get; set; }
        public double Re { get; set; }
        public double dt { get; set; }
        public IGrid1D Grid { get; set; }
        public int NGrid { get; set; }

        public void SolveExact()
        {
            using (DbSolutionContext context = new DbSolutionContext())
            {
                var grid = context.CreateGrid(0, 1, NGrid);

                var solution = context.CreateExactTimeDependentSolution(grid, new { Re, s }, dt);
                context.SaveChanges();

                IStopCondition stopCondition = new TimeLimitCondition(PulsationLaminarModel.TimeMax);          

                solution.FillExactAsync((r, t) => u(s, Re, r, t), stopCondition);                
            }
        }

        public void Solve(IScheme1D scheme)
        {
            using (DbSolutionContext context = new DbSolutionContext())
            {
                var grid = context.CreateGrid(0, 1, NGrid);
                var solution = context.CreateNumericTimeDependentSolution(grid, new { Re, s }, dt,
                                                                          scheme.GetType());
                context.SaveChanges();

                solution.AddLayer(new double[NGrid]);

                IStopCondition stopCondition = new TimeLimitCondition(PulsationLaminarModel.TimeMax);
                IBoundaryCondition leftBoundaryCondition = new BoundaryCondition(BoundaryConditionLocation.Left,
                                                                                 BoundaryConditionType.Neumann);
                IBoundaryCondition rightBoundaryCondition = new BoundaryCondition(BoundaryConditionLocation.Right,
                                                                                  BoundaryConditionType.Dirichlet); 
               
                scheme.Solve(solution, leftBoundaryCondition, rightBoundaryCondition, stopCondition);
            }
        }

        public void SolveImplicit()
        {
            Solve(new DiffusionImplicitCylindricScheme1D((r, t) => f(s, Re, r, t), 1/s));
        }

        public void SolveCrankNikolson()
        {
            Solve(new CrankNicolsonCylindricScheme1D((r, t) => f(s, Re, r, t), 1 / s));
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