using System;
using Calculation.UI.Models;

namespace Calculation.UI.Views
{
    public interface ISolutionsView
    {
        SolutionsGroupModel Group { get; set; }

        event EventHandler Initialized;

        event EventHandler LayerChanged;

        void RefreshArea();
    }
}