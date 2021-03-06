using System;
using System.Collections.Generic;
using System.Linq;
using Calculation.Classes.Algorithms.Common.Extensions;
using Calculation.Classes.Algorithms.TimeDependent.Extensions;
using Calculation.Classes.Data;
using Calculation.UI.Models;
using Calculation.UI.Views;
using OpenGlExtensions.Classes;

namespace Calculation.UI.Presenters
{
    public class SolutionsPresenter : ISolutionsPresenter
    {
        public SolutionsPresenter(ISolutionsView view)
        {
            View = view;
            View.Initialized += OnViewInitialized;
        }

        public virtual void FillData()
        {            
            List<SolutionItemColoredModel> solutionItems = View.Model.SolutionItems;

            View.FillListView(solutionItems);

            View.Model.Curves.Clear(); 

            using (CalculationDbContext db = new CalculationDbContext())
            {
                foreach (var solutionItemColored in solutionItems)
                {                    
                    var solutionItem = solutionItemColored.Item;
                    var bundle = db.GetBundle(solutionItem.Id);
                    var grid = bundle.GetGrid();
                    if (!bundle.IsSequence)
                    {
                        var array = bundle.GetArray(0);
                        Curve2D curve = new Curve2D(grid.Values, array.Values, solutionItemColored.Color);
                        View.Model.Curves.Add(Guid.NewGuid().ToString(), curve);
                    }
                }
            }
        }

        public void RefreshArea()
        {
            View.Context2D.Refresh();
        }

        public void DrawCurves()
        {
            View.Context2D.ClearArea();
            foreach (var curves in View.Model.Curves)
            {
                View.Context2D.AddShape(curves.Value);
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
            View.Context2D.Refresh();
        }

        protected virtual void SetAreaBoundaries()
        {
            Func<Curve2D, double> xMax = l => l.Points.Max(p => p.X);
            Func<Curve2D, double> xMin = l => l.Points.Min(p => p.X);
            Func<Curve2D, double> yMax = l => l.Points.Max(p => p.Y);
            Func<Curve2D, double> yMin = l => l.Points.Min(p => p.Y);
            var curves = View.Model.Curves.Values;
            View.Context2D.SetAreaBoundaries(curves.Min(xMin), curves.Max(xMax), curves.Min(yMin), curves.Max(yMax), 0.1);
        }

        public ISolutionsView View { get; set; }
    }
}