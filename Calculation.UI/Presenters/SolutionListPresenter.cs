using System;
using System.Collections.ObjectModel;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Windows.Forms;
using Calculation.Classes.Data;
using Calculation.Export;
using Calculation.UI.Helpers;
using Calculation.UI.Models;
using Calculation.UI.Views;
using Pulsation.Models;
using Pulsation.Solvers;

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
            View.ExportClicked += OnExportClicked;
            View.CalculateAlphaClicked += OnCalculateAlphaClicked;
        }

        private void OnExportClicked(object sender, EventArgs e)
        {
            if (View.SelectedItem != null)
            {
                var item = View.SelectedItem;
                SaveFileDialog saveFileDialog = new SaveFileDialog
                                                    {Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*"};
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filename = saveFileDialog.FileName;
                    ArraysExporter exporter = new ArraysExporter();
                    using (CalculationDbContext db = new CalculationDbContext())
                    {
                        var bundle = db.GetBundle(item.Id);
                        var arrays = bundle.GetAllArrays();
                        exporter.ExportToFile(filename, bundle.GetData<PulsationData>(), arrays);
                    }
                }
            }
        }

        private void OnCalculateAlphaClicked(object sender, EventArgs e)
        {
            var solutionItem = View.SelectedItem;
            if (solutionItem != null)
            {
                PulsationAlphaSolver solver = new PulsationAlphaSolver();
                using(CalculationDbContext db = new CalculationDbContext())
                {
                    var group = db.GetBundle(solutionItem.Id);
                    var pulsationData = group.GetData<PulsationData>();
                    PulsationAlphaData data = new PulsationAlphaData(pulsationData, group);
                    solver.Solve("Alpha", data);
                }
            }
        }

        private void OnRefreshClicked(object sender, EventArgs e)
        {
            FillData();
        }

        private void OnDeleteClicked(object sender, EventArgs e)
        {
            using (CalculationDbContext db = new CalculationDbContext())
            {
                foreach (var item in View.SelectedItems)
                {
                    db.DeleteBundle(item.Id);
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
            using(CalculationDbContext db = new CalculationDbContext())
            {
                var solutions = db.GetGroups();
                var solutionsList = solutions.Select(s => s.ToItemModel(s.GetData<PulsationData>())).ToList();
                View.SolutionsList.Solutions = new ObservableCollection<PulsationSolutionItemModel>(solutionsList);
            }            
            View.Bind();
        }

        public ISolutionListView View { get; private set; }
    }
}