using System;
using System.Collections.Generic;
using OpenGlExtensions.Interfaces;
using Pulsation.WinForms.Presenters;
using Pulsation.WinForms.ViewModels;
using Schemes.TimeDependent1D;

namespace Pulsation.WinForms.Views
{
    public interface IPulsationLaminarComparisonView
    {
        PulsationLaminarPresenter Presenter { get; }

        PulsationLaminarSolutionViewModel ViewModel { get; set; }

        #region Controls
        IOpenGlContext2D Context2D { get; }
        #endregion 
    }
}