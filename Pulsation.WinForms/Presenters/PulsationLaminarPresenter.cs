﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using OpenGlExtensions.Classes;
using Pulsation.Models;
using Pulsation.Solvers;
using Pulsation.WinForms.ViewModels;
using Pulsation.WinForms.Views;
using Schemes.TimeDependent1D;

namespace Pulsation.WinForms.Presenters
{
    public class PulsationLaminarPresenter
    { 
        public PulsationLaminarPresenter(IPulsationLaminarView view)
        {
            View = view;
            view.SolveClicked += OnViewSolveClicked;

            ViewModel = new PulsationLaminarExactSolutionViewModel();
            ViewModel.ImplicitSchemeSolutionVisibleChanged += OnViewModelImplicitSchemeSolutionVisibleChanged;
            ViewModel.ExactSolutionVisibleChanged += OnViewModelExactSolutionVisibleChanged;
            ViewModel.CurrentLayerIndexChanged += OnViewModelCurrentLayerIndexChanged;
        }

        protected virtual void OnViewModelImplicitSchemeSolutionVisibleChanged(object sender, EventArgs e)
        {
            RefreshCurves();
        }

        protected virtual void OnViewModelExactSolutionVisibleChanged(object sender, EventArgs e)
        {
            RefreshCurves();
        }

        public IPulsationLaminarView View { get; set; }

        public PulsationLaminarExactSolutionViewModel ViewModel
        {
            get { return View.ViewModel; }
            set { View.ViewModel = value; }
        }

        protected void RefreshCurves()
        {
            if (ViewModel.Solved)
            {
                int index = ViewModel.CurrentLayerIndex;
                foreach (var curves in ViewModel.CurveGroups)
                {
                    curves.Value.ForEach(l => l.Visible = false);
                    if (index<curves.Value.Count)
                    {
                        if (ViewModel.ExactSolutionVisible && curves.Key == "Exact")
                        {
                            curves.Value[index].Visible = true;
                        }
                        if (ViewModel.ImplicitSchemeSolutionVisible && curves.Key == "ImplicitScheme")
                        {
                            curves.Value[index].Visible = true;
                        }
                    }
                }
                View.Context2D.Refresh();
            }
        }

        protected virtual void OnViewModelCurrentLayerIndexChanged(object sender, EventArgs e)
        {
            RefreshCurves();
        }

        protected virtual void SetAreaBoundaries(params TimeDependent1DSolution[] solutions)
        {
            Func<TimeDependent1DSolution, double> xMax = s => s.Layers.Max(l => l.Max());
            Func<TimeDependent1DSolution, double> xMin = s => s.Layers.Min(l => l.Min());
            Func<TimeDependent1DSolution, double> yMax = s => s.Grid.Max;
            Func<TimeDependent1DSolution, double> yMin = s => s.Grid.Min;

            View.Context2D.SetAreaBoundaries(solutions.Min(xMin), solutions.Max(xMax), solutions.Min(yMin), solutions.Max(yMax),
                ViewModel.ChartPaddingInPercent);
        }

        protected virtual void OnViewSolveClicked(object sender, EventArgs e)
        {
            ViewModel.CurrentLayerIndex = 0;
            var implicitSchemeSolver = new PulsationLaminarImplicitSchemeSolver(ViewModel.PhysicalData);
            var implicitSchemeSolution = implicitSchemeSolver.Solve(ViewModel.CalculationData);
            var implicitSchemeCurves = ToCurves2D(implicitSchemeSolution, Color.Black);

            var exactSolver = new PulsationLaminarExactSolver(ViewModel.PhysicalData);
            var exactSolution = exactSolver.Solve(ViewModel.CalculationData);
            var exactCurves = ToCurves2D(exactSolution, Color.Red);

            ViewModel.CurveGroups.Clear();
            ViewModel.CurveGroups.Add("ImplicitScheme", implicitSchemeCurves);
            ViewModel.CurveGroups.Add("Exact", exactCurves);
            
            SetAreaBoundaries(exactSolution, implicitSchemeSolution);

            ShowSolutions();
            ViewModel.Solved = true;
            ShowTrackBar();
        }

        protected virtual List<Curve2D> ToCurves2D(TimeDependent1DSolution solution, Color color)
        {
            return solution.Layers.Select((l, i) => ToCurve2D(solution.Grid, l, color)).ToList();
        }

        protected virtual Curve2D ToCurve2D(Grid1D grid, double[] layer, Color color)
        {
            return new Curve2D(layer, grid.ToArray()) {Color = color};
        }

        protected virtual void ShowSolutions()
        {
            var calculationData = ViewModel.CalculationData;
            int nTime = calculationData.NTime;
            View.Context2D.ClearArea();
            for (int i = 0; i < nTime; i++)
            {
                foreach (var curves in ViewModel.CurveGroups)
                {
                    View.Context2D.AddShape(curves.Value[i]);
                }
            }      
        } 

        protected virtual void ShowTrackBar()
        {
            ViewModel.CurrentLayerIndex = 0;
            ViewModel.Solved = true;
        }
    }
}