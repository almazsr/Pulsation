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

        PulsationSolutionItemModel SelectedItem { get; }

        List<PulsationSolutionItemModel> SelectedItems { get; }

        void Bind();

        event EventHandler ShowClicked;

        event EventHandler CompareClicked;

        event EventHandler DetailsClicked;

        event EventHandler CreateClicked;

        event EventHandler RefreshClicked;

        event EventHandler DeleteClicked;

        event EventHandler CalculateAlphaClicked;

        event EventHandler ExportClicked;

        event NotifyCollectionChangedEventHandler SolutionsCollectionChanged;
    }
}