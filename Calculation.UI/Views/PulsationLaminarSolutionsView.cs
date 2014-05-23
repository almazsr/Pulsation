using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Calculation.UI.Helpers;
using Calculation.UI.Models;
using Calculation.UI.Presenters;
using OpenGlExtensions.Interfaces;

namespace Calculation.UI.Views
{
    public partial class PulsationLaminarSolutionsView : Form, IPulsationLaminarSolutionsView
    {
        public PulsationLaminarSolutionsView(List<SolutionItemModel> solutionItems)
        {
            Model = new PulsationLaminarSolutionsModel(solutionItems);
            InitializeComponent();

            Presenter = new PulsationLaminarSolutionsPresenter(this);

            occLayers.InitializeContexts();
            Context2D = occLayers;

            Load += Initialized;
            trbnt.ValueChanged += LayerChanged;
            btnRefresh.Click += RefreshClicked;
        }

        public PulsationLaminarSolutionsModel Model { get; set; }

        public void Bind()
        {
            tbtdeg.AddBinding(c => c.Text, Model, m => m.TimeDeg, DataSourceUpdateMode.OnPropertyChanged);
            tbtrad.AddBinding(c => c.Text, Model, m => m.TimeRad, DataSourceUpdateMode.OnPropertyChanged);
            trbnt.AddBinding(c => c.Value, Model, m => m.CurrentLayerIndex, DataSourceUpdateMode.OnPropertyChanged);
            tbLayersCount.AddBinding(c => c.Text, Model, m => m.LayersCount);
            trbnt.AddBinding(c => c.Maximum, Model, m => m.LayersCount);
        }

        public void FillListView(List<SolutionItemColoredModel> solutionItems)
        {
            lvSolutions.Items.Clear();
            foreach (var solutionItemColored in solutionItems)
            {
                ListViewItem listViewItem = new ListViewItem(solutionItemColored.Item.Name);
                listViewItem.ForeColor = solutionItemColored.Color;
                lvSolutions.Items.Add(listViewItem);
            }
        }

        public PulsationLaminarSolutionsPresenter Presenter { get; set; }
        public int nt { get; set; }
        public event EventHandler Initialized;
        public event EventHandler RefreshClicked;
        public event EventHandler LayerChanged;

        public IOpenGlContext2D Context2D { get; private set; }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void tbtdeg_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
