using System;
using OpenGlExtensions.Interfaces;
using Pulsation.WinForms.Presenters;
using Pulsation.WinForms.ViewModels;

namespace Pulsation.WinForms.Views
{
    public interface IPulsationLaminarSolutionView
    {
        PulsationLaminarPresenter Presenter { get; }

        PulsationLaminarSolutionViewModel ViewModel { get; set; }

        #region Controls
        IOpenGlContext2D Context2D { get; }
        #endregion

        #region Events
        event EventHandler SolveClicked;
        #endregion
    }
}