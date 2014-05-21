using System;
using Calculation.Classes;
using Calculation.Classes.Schemes;
using Calculation.UI.Solvers;
using Calculation.UI.Views;
using Storage;

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
            using (DbSolutionContext db = new DbSolutionContext())
            {                
                if (model.Exact)
                {
                    PulsationLaminar.SolveExact(db, model);
                }
                if (model.Implicit)
                {
                    PulsationLaminar.SolveImplicit(db, model);
                }
                if (model.CrankNikolson)
                {
                    PulsationLaminar.SolveCrankNikolson(db, model);
                }
            }
        }

        private void OnViewInitialized(object sender, EventArgs e)
        {
            View.Bind();
        }        

        public IPulsationLaminarView View { get; private set; }
    }
}