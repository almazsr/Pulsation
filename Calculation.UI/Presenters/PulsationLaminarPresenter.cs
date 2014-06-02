using System;
using System.Linq;
using System.Windows.Forms;
using Calculation.Classes;
using Calculation.Classes.Schemes;
using Calculation.Classes.StopConditions;
using Calculation.Database;
using Calculation.Interfaces;
using Calculation.UI.Models;
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
            int M = 5;
            var timeMaxCondition = new TimeMaxCondition(PulsationLaminarModel.TimeMax);
            var timeMaxConditionForSchemes = new TimeMaxCondition(PulsationLaminarModel.TimeMax * M);
            var convergencePeriodicCondition = new ConvergencePeriodicCondition();
            IStopCondition[] stopConditions = new IStopCondition[]
                                                      {
                                                          model.TimeMaxOnly ? timeMaxConditionForSchemes : timeMaxCondition
                                                      };
            IStopCondition[] stopConditionsForSchemes = new IStopCondition[]
                                                      {
                                                          timeMaxConditionForSchemes
                                                      };
            if (!model.TimeMaxOnly)
            {
                stopConditionsForSchemes = stopConditionsForSchemes.Concat(new[] {convergencePeriodicCondition}).ToArray();
            }
            if (model.Exact)
            {
                solver.SolveExact(stopConditions);                
            }
            if (model.Implicit)
            {
                solver.SolveImplicit(stopConditionsForSchemes);
            }
            if (model.CrankNikolson)
            {
                solver.SolveCrankNikolson(stopConditionsForSchemes);
            }
        }

        private void OnViewInitialized(object sender, EventArgs e)
        {
            View.Bind();
        }        

        public IPulsationLaminarView View { get; private set; }
    }
}