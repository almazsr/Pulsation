using System;
using System.Collections.Generic;
using System.Collections.Specialized;
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
            SolutionsList.Solutions.CollectionChanged += SolutionsCollectionChanged;
            btnAlpha.Click += CalculateAlphaClicked;
            Load += Initialized;
        }

        public void Bind()
        {
            dgvSolutions.DataSource = SolutionsList.Solutions;                    
        }

        public SolutionItemModel SelectedItem
        {
            get
            {
                if (dgvSolutions.CurrentRow != null)
                {
                    return (SolutionItemModel) dgvSolutions.CurrentRow.DataBoundItem;
                }
                return null;
            }
        }

        public List<SolutionItemModel> SelectedItems
        {
            get
            {
                if (dgvSolutions.SelectedRows.Count > 0)
                {
                    return (from DataGridViewRow row in dgvSolutions.SelectedRows select (SolutionItemModel) row.DataBoundItem).ToList();
                }
                return new List<SolutionItemModel>();
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
        public event NotifyCollectionChangedEventHandler SolutionsCollectionChanged;
    }
}
