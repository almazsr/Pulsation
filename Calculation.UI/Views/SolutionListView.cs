using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

            Presenter = new SolutionsListPresenter(this);
            SolutionsList = new SolutionsListModel();

            btnShow.Click += ShowClicked;
            btnDelete.Click += DeleteClicked;
            btnCreate.Click += CreateClicked;
            btnCompare.Click += CompareClicked;
            btnRefresh.Click += RefreshClicked;
            SolutionsList.Solutions.CollectionChanged += SolutionsCollectionChanged;
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

        public SolutionsListModel SolutionsList { get; set; }
        public SolutionsListPresenter Presenter { get; private set; }
        public event EventHandler ShowClicked;
        public event EventHandler CompareClicked;
        public event EventHandler CreateClicked;
        public event EventHandler RefreshClicked;
        public event EventHandler Initialized;
        public event EventHandler DeleteClicked;
        public event NotifyCollectionChangedEventHandler SolutionsCollectionChanged;
    }
}
