using System;
using System.Collections.Generic;
using System.Linq;
using Calculation.Classes.Algorithms.Common.Extensions;
using Calculation.Classes.Algorithms.TimeDependent.Extensions;
using Calculation.Classes.Data;
using Calculation.Interfaces;
using Calculation.UI.Models;
using Calculation.UI.Views;
using OpenGlExtensions.Classes;
using Array = Calculation.Classes.Data.Array;

namespace Calculation.UI.Presenters
{
    public class TimeDependentSolutionsPresenter : ISolutionsPresenter
    {
        public TimeDependentSolutionsPresenter(ITimeDependentSolutionsView view)
        {
            View = view;
            View.Initialized += OnViewInitialized;
            View.Model.CurrentLayerIndexChanged += OnCurrentLayerChanged;
            View.RefreshClicked += OnRefreshClicked;            
        }

        private void OnCurrentLayerChanged(object sender, EventArgs e)
        {
            RefreshArea();
        }

        private void Refresh()
        {
            View.Model.CurrentLayerIndex = 0;
            InitializeArea();
        }

        private void OnRefreshClicked(object sender, EventArgs e)
        {
            Refresh();
        }

        public virtual void FillData()
        {
            int step = View.Model.Step;
            List<SolutionItemColoredModel> solutionItems = View.Model.SolutionItems;

            View.FillListView(solutionItems);

            View.Model.CurveGroups.Clear();
            using (CalculationDbContext db = new CalculationDbContext())
            {
                foreach (var solutionItemColored in solutionItems)
                {
                    var solutionItem = solutionItemColored.Item;
                    var bundle = db.GetBundle(solutionItem.Id);
                    var grid = bundle.GetGrid();
                    bool isPeriodic = bundle.IsPeriodic();

                    List<Array> layers = isPeriodic ?
                        bundle.GetLastPeriodLayers(step) :
                        bundle.GetSeparatedArrays(step);
                    List<Curve2D> curves =
                        layers.Select(l => new Curve2D(l.Values, grid.Values, solutionItemColored.Color)).ToList();
                    View.Model.CurveGroups.Add(Guid.NewGuid().ToString(), curves);
                }
            }
        }

        public void RefreshArea()
        {
            int index = View.Model.CurrentLayerIndex;
            foreach (var curves in View.Model.CurveGroups)
            {
                curves.Value.ForEach(l => l.Visible = false);
                curves.Value[index].Visible = true;
            }
            View.Context2D.Refresh();
        }

        public void DrawCurves()
        {
            int layersCount = View.Model.Count;
            View.Context2D.ClearArea();
            for (int i = 0; i < layersCount; i++)
            {
                foreach (var curves in View.Model.CurveGroups)
                {
                    View.Context2D.AddShape(curves.Value[i]);
                }
            }
        }

        protected void OnViewInitialized(object sender, EventArgs e)
        {
            View.Bind();
            InitializeArea();
        }

        protected void InitializeArea()
        {
            FillData();
            SetAreaBoundaries();
            DrawCurves();
            RefreshArea();
        }

        protected virtual void SetAreaBoundaries()
        {
            Func<List<Curve2D>, double> xMax = s => s.Max(l => l.Points.Max(p => p.X));
            Func<List<Curve2D>, double> xMin = s => s.Min(l => l.Points.Min(p => p.X));
            Func<List<Curve2D>, double> yMax = s => s.Max(l => l.Points.Max(p => p.Y));
            Func<List<Curve2D>, double> yMin = s => s.Min(l => l.Points.Min(p => p.Y));
            var curveGroups = View.Model.CurveGroups.Values;
            View.Context2D.SetAreaBoundaries(curveGroups.Min(xMin), curveGroups.Max(xMax), curveGroups.Min(yMin), curveGroups.Max(yMax),
                                             0.1);
        }

        public ITimeDependentSolutionsView View { get; set; }
    }
}