using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using Calculation.UI.Models;
using Calculation.UI.Presenters;

namespace Calculation.UI.Views
{
    public interface ISolutionListView
    {
        SolutionsListModel SolutionsList { get; set; }

        SolutionItemModel SelectedItem { get; }

        List<SolutionItemModel> SelectedItems { get; }

        void Bind();

        SolutionsListPresenter Presenter { get; }

        event EventHandler ShowClicked;

        event EventHandler CompareClicked;

        event EventHandler CreateClicked;

        event EventHandler RefreshClicked;

        event EventHandler Initialized;

        event EventHandler DeleteClicked;

        event NotifyCollectionChangedEventHandler SolutionsCollectionChanged;
    }
}