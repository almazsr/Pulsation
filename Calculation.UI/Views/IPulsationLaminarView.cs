using System;
using Calculation.UI.Models;
using Calculation.UI.Presenters;

namespace Calculation.UI.Views
{
    public interface IPulsationLaminarView : IView<PulsationLaminarPresenter>
    {
        PulsationLaminarModel Model { get; set; }

        void Bind();

        event EventHandler ShowClicked;

        event EventHandler SolveClicked;

        void Progress(int percentage);
    }
}