using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Forms;
using Calculation.Database;
using Calculation.UI.Helpers;
using Calculation.UI.Models;
using Calculation.UI.Views;

namespace Calculation.UI.Presenters
{
    public class SolutionsListPresenter
    {
        public SolutionsListPresenter(ISolutionListView view)
        {
            View = view;
            View.Initialized += OnViewInitialized;
            View.CreateClicked += OnCreateClicked;
            View.CompareClicked += OnCompareClicked;
            View.ShowClicked += OnShowClicked;
            View.DeleteClicked += OnDeleteClicked;
        }

        private void OnDeleteClicked(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void OnShowClicked(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void OnCompareClicked(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void OnCreateClicked(object sender, EventArgs e)
        {
            PulsationLaminarView view = new PulsationLaminarView();
            if (view.ShowDialog() == DialogResult.OK)
            {
                var model = view.Model;
            }
        }

        private void OnViewInitialized(object sender, EventArgs e)
        {
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