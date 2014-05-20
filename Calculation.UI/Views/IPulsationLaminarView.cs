﻿using System;
using Calculation.UI.Models;
using Calculation.UI.Presenters;

namespace Calculation.UI.Views
{
    public interface IPulsationLaminarView
    {
        PulsationLaminarModel Model { get; set; }

        PulsationLaminarPresenter Presenter { get; }

        int Progress { get; set; }

        event EventHandler ShowClicked;

        event EventHandler SolveClicked;

        event EventHandler CancelClicked;       
    }
}