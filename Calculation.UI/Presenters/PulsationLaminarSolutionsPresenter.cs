using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Calculation.Database;
using Calculation.UI.Helpers;
using Calculation.UI.Models;
using Calculation.UI.Views;
using OpenGlExtensions.Classes;

namespace Calculation.UI.Presenters
{
    public class PulsationLaminarSolutionsPresenter
    {
        public PulsationLaminarSolutionsPresenter(IPulsationLaminarSolutionsView view)
        {
            View = view;
            View.Model.CurrentLayerIndexChanged += OnLayerChanged;
            View.RefreshClicked += OnRefreshClicked;
            View.Initialized += OnViewInitialized;
        }

        private void OnRefreshClicked(object sender, EventArgs e)
        {
            View.Model.CurrentLayerIndex = 0;            
            InitializeArea();
        }

        public void FillData()
        {
            int count = View.Model.LayersCount;
            List<SolutionItemColoredModel> solutionItems = View.Model.SolutionItems;

            View.FillListView(solutionItems);

            View.Model.CurveGroups.Clear(); 
            using (DbSolutionContext db = new DbSolutionContext())
            {
                int index = 0;
                foreach (var solutionItemColored in solutionItems)
                {
                    var solutionItem = solutionItemColored.Item;
                    var grid = db.GetGrid(solutionItem.Id);
                    var layers = db.GetLayers(solutionItem.Id, count);
                    List<Curve2D> curves =
                        layers.Select(l => new Curve2D(l.ToArray(), grid.ToArray(), solutionItemColored.Color)).ToList();
                    View.Model.CurveGroups.Add(solutionItem.Name, curves);   
                    index++;                               
                }
            }
        }

        public void RefreshArea()
        {
            int index = View.Model.CurrentLayerIndex;
            foreach (var curves in View.Model.CurveGroups)
            {                
                curves.Value.ForEach(l => l.Visible = false);
                if (index < curves.Value.Count)
                {
                    curves.Value[index].Visible = true;
                }
            }
            View.Context2D.Refresh();
        }

        public void DrawCurves()
        {
            int layersCount = View.Model.LayersCount;
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

        protected void OnLayerChanged(object sender, EventArgs e)
        {
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
                View.Model.ChartPaddingInPercent);
        }

        public IPulsationLaminarSolutionsView View { get; set; }
    }
}