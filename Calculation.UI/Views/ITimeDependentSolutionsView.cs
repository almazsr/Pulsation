using System;
using System.Collections.Generic;
using Calculation.UI.Models;
using Calculation.UI.Presenters;

namespace Calculation.UI.Views
{
    public interface ITimeDependentSolutionsView : IChartView, IView<TimeDependentSolutionsPresenter>
    {
        SolutionsTimeDependentModel Model { get; set; }

        void Bind();

        void FillListView(List<SolutionItemColoredModel> solutionItems);

        event EventHandler RefreshClicked;
    }
}