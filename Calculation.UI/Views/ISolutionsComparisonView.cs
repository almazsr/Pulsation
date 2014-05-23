﻿using System;
using System.Collections.Generic;
using Calculation.UI.Models;
using Calculation.UI.Presenters;
using OpenGlExtensions.Interfaces;

namespace Calculation.UI.Views
{
    public interface ISolutionsComparisonView
    {
        PulsationLaminarSolutionsModel Model { get; set; }

        void FillListView(List<SolutionItemColoredModel> solutionItems);

        PulsationLaminarComparisonPresenter Presenter { get; set; }

        event EventHandler Initialized;

        #region Controls
        IOpenGlContext2D Context2D { get; }
        #endregion 
    }
}