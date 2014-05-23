using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Calculation.UI.Models;
using Calculation.UI.Presenters;
using OpenGlExtensions.Interfaces;

namespace Calculation.UI.Views
{
    public interface IPulsationLaminarSolutionsView
    {
        PulsationLaminarSolutionsModel Model { get; set; }

        void Bind();

        void FillListView(List<SolutionItemColoredModel> solutionItems);

        PulsationLaminarSolutionsPresenter Presenter { get; set; }

        event EventHandler Initialized;

        event EventHandler RefreshClicked;

        #region Controls
        IOpenGlContext2D Context2D { get; }
        #endregion 
    }
}