using System.Collections.Generic;
using System.Linq;
using Calculation.Database;
using Calculation.Helpers;
using Calculation.UI.Models;
using Calculation.UI.Views;
using OpenGlExtensions.Classes;

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
            using (DbSolutionContext db = new DbSolutionContext())
            {
                var exactSolution = solutionItems.FirstOrDefault(s => s.Item.IsExact);
                var exactLayers = db.GetAllLayers(exactSolution.Item.Id);
                List<Curve2D> curves = new List<Curve2D>();
                foreach (var solutionItemColored in solutionItems)
                {
                    var solutionItem = solutionItemColored.Item;
                    if (!solutionItem.IsExact)
                    {
                        var layers = db.GetAllLayers(solutionItem.Id);                        
                        Curve2D curve = new Curve2D(solutionItemColored.Color);     
                        for (int i = 0; i < exactLayers.Count; i++)
                        {
                            double max = exactLayers[i].Subtract(layers[i]).NormInf();
                            curve.Add(exactLayers[i].t, max);
                        }
                        curves.Add(curve);
                        View.Model.Curves.Add(solutionItem.Name, curve);
                    }
                }
            }
        }
    }
}