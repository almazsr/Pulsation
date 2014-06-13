using System;
using Calculation.UI.Models;
using Calculation.UI.Presenters;
using Pulsation.Models;

namespace Calculation.UI.Views
{
    public interface IPulsationLaminarView : IView<PulsationPresenter>
    {
        PulsationModel Model { get; set; }

        void Bind();

        event EventHandler ShowClicked;

        event EventHandler SolveClicked;
    }
}