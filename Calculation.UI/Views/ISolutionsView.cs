using System.Collections.Generic;
using Calculation.UI.Models;
using Calculation.UI.Presenters;

namespace Calculation.UI.Views
{
    public interface ISolutionsView : IChartView, IView<SolutionsPresenter>
    {
        SolutionsCurvesModel Model { get; set; }

        void FillListView(List<SolutionItemColoredModel> solutionItems);
    }
}