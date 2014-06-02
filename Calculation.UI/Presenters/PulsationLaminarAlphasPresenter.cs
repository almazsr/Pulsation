using System;
using Calculation.UI.Solvers;
using Calculation.UI.Views;

namespace Calculation.UI.Presenters
{
    public class PulsationLaminarAlphasPresenter
    {
        public PulsationLaminarAlphasPresenter(IPulsationLaminarAlphasView view)
        {
            View = view;
            view.SolveClicked += OnSolveClicked;
            view.Initialized += OnViewInitialized;
        }

        private void OnSolveClicked(object sender, EventArgs e)
        {
            PulsationLaminarSolver.CalculateAlpha1(View.Model.SolutionId);
            PulsationLaminarSolver.CalculateAlpha2(View.Model.SolutionId);
        }

        private void OnViewInitialized(object sender, EventArgs e)
        {

        }

        public IPulsationLaminarAlphasView View { get; private set; }
    }
}