using OpenGlExtensions.Interfaces;
using Pulsation.UI.Presenters;
using Pulsation.UI.ViewModels;

namespace Pulsation.UI.Views
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