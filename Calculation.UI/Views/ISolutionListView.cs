using System;
using System.Collections.Specialized;
using Calculation.UI.Models;
using Calculation.UI.Presenters;

namespace Calculation.UI.Views
{
    public interface ISolutionListView
    {
        SolutionsListModel SolutionsList { get; set; }

        void Bind();

        SolutionsListPresenter Presenter { get; }

        event EventHandler ShowClicked;

        event EventHandler CompareClicked;

        event EventHandler CreateClicked;

        event EventHandler Initialized;

        event EventHandler DeleteClicked;

        event NotifyCollectionChangedEventHandler SolutionsCollectionChanged;
    }
}