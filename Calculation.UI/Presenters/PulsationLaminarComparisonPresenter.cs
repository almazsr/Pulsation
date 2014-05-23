using System;
using System.Collections.Generic;
using System.Linq;
using Calculation.Database;
using Calculation.UI.Models;
using Calculation.UI.Views;
using OpenGlExtensions.Classes;

namespace Calculation.UI.Presenters
{
    public class PulsationLaminarComparisonPresenter
    {
         public PulsationLaminarComparisonPresenter(ISolutionsComparisonView view)
        {
            View = view;
            View.Model.CurrentLayerIndexChanged += OnLayerChanged;
            View.Initialized += OnViewInitialized;
        }

        public void FillData()
        {
            int count = View.Model.LayersCount;
            List<SolutionItemColoredModel> solutionItems = View.Model.SolutionItems;

            View.FillListView(solutionItems);

            View.Model.CurveGroups.Clear(); 
            using (DbSolutionContext db = new DbSolutionContext())
            {
                var exactSolution = solutionItems.FirstOrDefault(s => s.Item.IsExact);
                var exactLayers = db.GetLayers(exactSolution.Item.Id, count);
                List<Curve2D> curves = new List<Curve2D>();
                foreach (var solutionItemColored in solutionItems)
                {
                    var solutionItem = solutionItemColored.Item;
                    if (!solutionItem.IsExact)
                    {
                        var layers = db.GetLayers(solutionItem.Id, count);
                        Curve2D curve = new Curve2D(solutionItemColored.Color);
                        for (int i = 0; i < exactLayers.Count;i++ )
                        {
                            var layerArray = layers[i].ToArray();
                            var exactLayerArray = exactLayers[i].ToArray();
                            double max = exactLayerArray.Select((x, j) => Math.Abs(x - layerArray[j])).Max();
                            curve.Add(exactLayers[i].t, max);
                        }
                        curves.Add(curve);                        
                    }
                }
                View.Model.CurveGroups.Add("Comparison", curves);
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

        public ISolutionsComparisonView View { get; set; }
    }
}