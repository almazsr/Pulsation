using System;
using System.Windows.Forms;
using Calculation.Classes;
using Calculation.Classes.Schemes;
using Calculation.Database;
using Calculation.UI.Solvers;
using Calculation.UI.Views;

namespace Calculation.UI.Presenters
{
    public class PulsationLaminarPresenter
    {
         public PulsationLaminarPresenter(IPulsationLaminarView view)
         {
             View = view;
             view.SolveClicked += OnSolveClicked;
             view.Initialized += OnViewInitialized;             
         }

        private void OnSolveClicked(object sender, EventArgs e)
        {
            var model = View.Model;
            PulsationLaminarSolver solver = new PulsationLaminarSolver(model);
            
            if (model.Exact)
            {
                solver.SolveExact();                
            }
            if (model.Implicit)
            {
                solver.SolveImplicit();
            }
            if (model.CrankNikolson)
            {
                solver.SolveCrankNikolson();
            }
        }

        private void OnViewInitialized(object sender, EventArgs e)
        {
            View.Bind();
        }        

        public IPulsationLaminarView View { get; private set; }
    }
}