using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Calculation.Classes.Data;
using Calculation.Helpers;
using Calculation.UI.Models;
using Calculation.UI.Views;
using OpenGlExtensions.Classes;
using Pulsation.Solvers;

namespace Calculation.UI.Presenters
{
    public class SolutionsComparisonPresenter : SolutionsPresenter
    {
        public SolutionsComparisonPresenter(ISolutionsView view) : base(view)
        {
        }

        public override void FillData()
        {            
            List<SolutionItemColoredModel> solutionItems = View.Model.SolutionItems;

            View.FillListView(solutionItems);

            View.Model.Curves.Clear();
            string exactSolverType = typeof(PulsationLaminarExactSolver).Name;
            using (CalculationDbContext db = new CalculationDbContext())
            {
                var exactSolution = solutionItems.FirstOrDefault(s => s.Item.SolverType == exactSolverType);
                if (exactSolution == null) return;

                int exactSolutionId = exactSolution.Item.Id;
                var exactBundle = db.GetBundle(exactSolutionId);
                var exactLayers = exactBundle.GetAllArrays();
                List<Curve2D> curves = new List<Curve2D>();
                foreach (var solutionItemColored in solutionItems)
                {
                    var solutionItem = solutionItemColored.Item;
                    var bundle = db.GetBundle(exactSolutionId);
                    if (solutionItem.SolverType != exactSolverType)
                    {
                        var layers = bundle.GetAllArrays();                        
                        Curve2D curve = new Curve2D(solutionItemColored.Color);
                        double t = 0;
                        for (int i = 0; i < exactSolution.Item.Count; i++)
                        {
                            double max = exactLayers[i].Subtract(layers[i]).NormInf();
                            curve.Add(t, max);
                            t += solutionItem.dt;
                        }
                        curves.Add(curve);
                        View.Model.Curves.Add(solutionItem.Name, curve);
                    }
                }
            }
        }
    }
}