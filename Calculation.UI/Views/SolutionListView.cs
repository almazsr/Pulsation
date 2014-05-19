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
            SolutionsList.Solutions.CollectionChanged += SolutionsCollectionChanged;
            Load += Initialized;
        }

        public void Bind()
        {
            dgvSolutions.DataSource = SolutionsList.Solutions;            
        }

        public SolutionsListModel SolutionsList { get; set; }
        public SolutionsListPresenter Presenter { get; private set; }
        public event EventHandler ShowClicked;
        public event EventHandler CompareClicked;
        public event EventHandler CreateClicked;
        public event EventHandler Initialized;
        public event EventHandler DeleteClicked;
        public event NotifyCollectionChangedEventHandler SolutionsCollectionChanged;
    }
}
