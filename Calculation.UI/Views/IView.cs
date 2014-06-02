using System;

namespace Calculation.UI.Views
{
    public interface IView<out TPresenter> where TPresenter : class
    {
        event EventHandler Initialized; 

        TPresenter Presenter { get; }
    }
}