using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Forms;
using Calculation.Database;
using Calculation.UI.Helpers;
using Calculation.UI.Models;
using Calculation.UI.Solvers;
using Calculation.UI.Views;

namespace Calculation.UI.Presenters
{
    public class SolutionListPresenter
    {
        public SolutionListPresenter(ISolutionListView view)
        {
            View = view;
            View.Initialized += OnViewInitialized;
            View.CreateClicked += OnCreateClicked;
            View.CompareClicked += OnCompareClicked;
            View.ShowClicked += OnShowClicked;
            View.DeleteClicked += OnDeleteClicked;
            View.RefreshClicked += OnRefreshClicked;
            View.CalculateAlphaClicked += OnCalculateAlphaClicked;
        }

        private void OnCalculateAlphaClicked(object sender, EventArgs e)
        {
            var solutionItem = View.SelectedItem;
            if (solutionItem != null)
            {
                PulsationLaminarSolver.CalculateAlpha1(solutionItem.Id);
                PulsationLaminarSolver.CalculateAlpha2(solutionItem.Id);
            }
        }

        private void OnRefreshClicked(object sender, EventArgs e)
        {
            FillData();
        }

        private void OnDeleteClicked(object sender, EventArgs e)
        {
            using (DbSolutionContext db = new DbSolutionContext())
            {
                foreach (var item in View.SelectedItems)
                {
                    db.DeleteSolution(item.Id);
                }
                db.SaveChanges();
            }
            FillData();
        }

        private void OnShowClicked(object sender, EventArgs e)
        {
            var solutionItems = View.SelectedItems;
            if (solutionItems.All(s=>s.IsTimeDependent))
            {
                var view = new TimeDependentSolutionsView(View.SelectedItems);
                view.ShowDialog();
            }
            else if (!solutionItems.All(s=>s.IsTimeDependent))
            {
                var view = new SolutionsView(View.SelectedItems);
                view.ShowDialog();
            }
        }

        private void OnCompareClicked(object sender, EventArgs e)
        {
            var view = new SolutionsView(View.SelectedItems, true);
            view.ShowDialog();
        }

        private void OnCreateClicked(object sender, EventArgs e)
        {
            var view = new PulsationLaminarView();
            if (view.ShowDialog() == DialogResult.OK)
            {
                FillData();
            }
        }

        private void OnViewInitialized(object sender, EventArgs e)
        {
            View.Bind();
            FillData();
        }

        public void FillData()
        {
            using(DbSolutionContext db = new DbSolutionContext())
            {
                var solutions = db.GetSolutions();
                var solutionsList = solutions.Select(s => s.ToItemModel()).ToList();
                View.SolutionsList.Solutions = new ObservableCollection<SolutionItemModel>(solutionsList);
            }            
            View.Bind();
        }

        public ISolutionListView View { get; private set; }
    }
}