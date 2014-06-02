using System;
using Calculation.UI.Models;
using Calculation.UI.Presenters;

namespace Calculation.UI.Views
{
    public interface IPulsationLaminarAlphasView : IView<PulsationLaminarAlphasPresenter>
    {
        PulsationLaminarAlphasModel Model { get; set; }

        event EventHandler SolveClicked;

        void Progress(int percentage); 
    }
}