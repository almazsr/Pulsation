using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Calculation.UI.Models;
using Calculation.UI.Presenters;
using OpenGlExtensions.Classes;

namespace Calculation.UI.Views
{
    public interface IPulsationLaminarView
    {
        PulsationLaminarModel Model { get; set; }

        void Bind();

        PulsationLaminarPresenter Presenter { get; }

        event EventHandler ShowClicked;

        event EventHandler SolveClicked;

        event EventHandler Initialized;

        void Progress(int percentage);
    }
}