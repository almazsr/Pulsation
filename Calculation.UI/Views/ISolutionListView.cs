using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using Calculation.UI.Models;
using Calculation.UI.Presenters;

namespace Calculation.UI.Views
{
    public interface ISolutionListView : IView<SolutionListPresenter>
    {
        SolutionListModel SolutionsList { get; set; }

        SolutionItemModel SelectedItem { get; }

        List<SolutionItemModel> SelectedItems { get; }

        void Bind();

        event EventHandler ShowClicked;

        event EventHandler CompareClicked;

        event EventHandler DetailsClicked;

        event EventHandler CreateClicked;

        event EventHandler RefreshClicked;

        event EventHandler DeleteClicked;

        event EventHandler CalculateAlphaClicked;

        event NotifyCollectionChangedEventHandler SolutionsCollectionChanged;
    }
}