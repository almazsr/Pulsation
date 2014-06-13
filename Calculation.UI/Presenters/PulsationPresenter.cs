using System;
using Calculation.UI.Views;
using Pulsation.Solvers;

namespace Calculation.UI.Presenters
{
    public class PulsationPresenter
    {
        public PulsationPresenter(IPulsationLaminarView view)
        {
            View = view;
            view.SolveClicked += OnSolveClicked;
            view.Initialized += OnViewInitialized;
        }

        private void OnSolveClicked(object sender, EventArgs e)
        {
            var model = View.Model;
            PulsationSolver.Solve(model);
        }

        private void OnViewInitialized(object sender, EventArgs e)
        {
            View.Bind();
        }        

        public IPulsationLaminarView View { get; private set; }
    }
}