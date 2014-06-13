using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Calculation.UI.Models;
using Calculation.UI.Presenters;

namespace Calculation.UI.Views
{
    public partial class SolutionListView : Form, ISolutionListView
    {
        public SolutionListView()
        {
            InitializeComponent(); 

            SolutionsList = new SolutionListModel();
            Presenter = new SolutionListPresenter(this);
            
            btnShow.Click += ShowClicked;
            btnDelete.Click += DeleteClicked;
            btnCreate.Click += CreateClicked;
            btnCompare.Click += CompareClicked;
            btnRefresh.Click += RefreshClicked;
            btnAlpha.Click += CalculateAlphaClicked;
            btnExport.Click += ExportClicked;
            Load += Initialized;
        }

        public void Bind()
        {
            dgvSolutions.ColumnsHierarchy.AutoStretchColumns = true;
            dgvSolutions.ColumnsHierarchy.AllowDragDrop = true;
            dgvSolutions.DataSource = SolutionsList.Solutions;
            dgvSolutions.DataBind();
        }

        public PulsationSolutionItemModel SelectedItem
        {
            get
            {
                var items = dgvSolutions.RowsHierarchy.SelectedItems;
                if (items.Length > 0)
                {
                    if (items[0].BoundFieldIndex >= 0 && items[0].BoundFieldIndex < SolutionsList.Solutions.Count)
                    {
                        return SolutionsList.Solutions[items[0].BoundFieldIndex];
                    }
                }
                return null;
            }
        }

        public List<PulsationSolutionItemModel> SelectedItems
        {
            get
            {
                var items = dgvSolutions.RowsHierarchy.SelectedItems;
                if (items.Length > 0)
                {
                    return
                        items.Where(i => i.BoundFieldIndex >= 0 && i.BoundFieldIndex < SolutionsList.Solutions.Count).
                            Select(i => SolutionsList.Solutions[i.BoundFieldIndex]).ToList();
                }
                return null;
            }
        }

        public SolutionListModel SolutionsList { get; set; }
        public event EventHandler ShowClicked;
        public event EventHandler CompareClicked;
        public event EventHandler DetailsClicked;
        public event EventHandler CreateClicked;
        public event EventHandler RefreshClicked;
        public event EventHandler Initialized;
        public SolutionListPresenter Presenter { get; private set; }
        public event EventHandler DeleteClicked;
        public event EventHandler CalculateAlphaClicked;
        public event EventHandler ExportClicked;
        public event NotifyCollectionChangedEventHandler SolutionsCollectionChanged;

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
