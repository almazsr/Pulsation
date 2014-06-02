﻿using System;
using System.Diagnostics;
using System.Linq;
using Calculation.Classes;
using Calculation.Classes.Integrators;
using Calculation.Classes.Schemes;
using Calculation.Classes.StopConditions;
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
            this.beta = model.beta;
            this.dt = Math.PI * model.dAngle / 180;
            this.NGrid = model.NGrid;
        }

        public double s { get; set; }
        public double Re { get; set; }
        public double beta { get; set; }
        public double dt { get; set; }
        public IGrid1D Grid { get; set; }
        public int NGrid { get; set; }

        public void SolveExact(params IStopCondition[] stopConditions)
        {
            using (DbSolutionContext context = new DbSolutionContext())
            {
                var grid = context.CreateGrid(0, 1, NGrid);

                int N = (int)(PulsationLaminarModel.TimeMax / dt);

                var solution = context.CreateExactTimeDependentSolution(grid, new { Re, s }, dt);
                
                solution.SetPeriod(N);

                solution.Name = string.Format("PulsationLaminar.Exact for {0}", solution.PhysicalData);

                context.SaveChanges();

                solution.FillExactAsync(u, stopConditions);                
            }
        }

        public void Solve(IScheme1D scheme, params IStopCondition[] stopConditions)
        {
            using (DbSolutionContext context = new DbSolutionContext())
            {
                var grid = context.CreateGrid(0, 1, NGrid);
                var solution = context.CreateNumericTimeDependentSolution(grid, new {Re, s, beta}, dt,
                                                                          scheme.GetType()); 
                
                int N = (int)(PulsationLaminarModel.TimeMax / dt);
                solution.SetPeriod(N);

                solution.Name = string.Format("PulsationLaminar.Numeric for {0} with {1}", solution.PhysicalData,
                                              solution.SolverType);
                context.SaveChanges();

                double[] initialLayerValues = new double[NGrid];
                solution.AddLayer(initialLayerValues);

                IBoundaryCondition leftBoundaryCondition = new BoundaryCondition(BoundaryConditionLocation.Left,
                                                                                 BoundaryConditionType.Neumann);
                IBoundaryCondition rightBoundaryCondition = new BoundaryCondition(BoundaryConditionLocation.Right,
                                                                                  BoundaryConditionType.Dirichlet);
                scheme.Solve(solution, leftBoundaryCondition, rightBoundaryCondition, stopConditions);
            }
        }

        /// <summary>
        /// Подсчет коэффициентов alpha.
        /// </summary>
        public static void CalculateAlpha(int solutionId, int deg)
        {
            using (DbSolutionContext context = new DbSolutionContext())
            {
                var solution = context.GetSolution(solutionId);
                if (solution.IsPeriodic)
                {
                    double period = solution.PeriodNt*solution.dt;

                    var physicalData = context.GetPhysicalData(solutionId);
                    var grid = context.GetGrid(solutionId);
                    var alphaGrid = context.CreateGrid(0, period, solution.PeriodNt);
                    var alphaSolution = context.CreateNumericSolution(alphaGrid, physicalData, typeof (SimpsonIntegrator));
                    alphaSolution.Name = string.Format("PulsationLaminar.alpha{0} for {1}", deg, alphaSolution.PhysicalData);
                    context.SaveChanges();
                    try
                    {
                        alphaSolution.Start();

                        IIntegrator integrator = new SimpsonIntegrator();

                        var lastPeriodLayers = solution.GetLayers(solution.Nt - solution.PeriodNt, solution.PeriodNt);

                        double[] alphaValues = new double[alphaGrid.N];
                        for (int i = 0; i < alphaGrid.N; i++)
                        {
                            var layer = lastPeriodLayers[i];
                            var r = grid;
                            double[] u = layer.ToArray();
                            double[] ur = layer.ToArray().Select((uj, j) => uj*r[j]).ToArray();
                            double[] udeg = u.Select((uj,j) => Math.Pow(uj, deg)*r[j]).ToArray();
                            double uavg = 2*integrator.GetIntegral(ur, grid.h, grid.N);
                            alphaValues[i] = 2 * integrator.GetIntegral(udeg, grid.h, grid.N) / Math.Pow(uavg, deg);
                        }
                        alphaSolution.AddLayer(alphaValues);
                        alphaSolution.Finish(true);
                    }
                    catch (Exception exception)
                    {
                        solution.Finish(false);
                    }
                }
            }
        }

        /// <summary>
        /// Подсчет коэффициентов alpha1.
        /// </summary>
        public static void CalculateAlpha1(int solutionId)
        {
            CalculateAlpha(solutionId, 2);
        }

        /// <summary>
        /// Подсчет коэффициентов alpha2.
        /// </summary>
        public static void CalculateAlpha2(int solutionId)
        {
            CalculateAlpha(solutionId, 3);
        }

        public void SolveImplicit(params IStopCondition[] stopConditions)
        {
            Solve(new DiffusionImplicitCylindricScheme1D(f, 1/s), stopConditions);
        }

        public void SolveCrankNikolson(params IStopCondition[] stopConditions)
        {
            Solve(new CrankNicolsonCylindricScheme1D(f, 1 / s), stopConditions);
        }

        public double u(double r, double t)
        {
            double beis = SpecialFunctions.bei(s);
            double bers = SpecialFunctions.ber(s);
            double bei2sber2s = beis * beis + bers * bers;
            double beirs = SpecialFunctions.bei(r * s);
            double berrs = SpecialFunctions.ber(r * s);

            return Re / (s * s) *
                   ((1 - (beis * beirs + bers * berrs) / bei2sber2s) * Math.Sin(t) +
                    ((beis * berrs - bers * beirs) / bei2sber2s) * Math.Cos(t)+Math.Sin(t)+t);
        }

        public double f(double r, double t)
        {
            return Re/(s*s)*(beta*Math.Cos(t) + 1);
        }
    }
}