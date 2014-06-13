using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Calculation.UI.Helpers;
using Calculation.UI.Models;
using Calculation.UI.Presenters;
using OpenGlExtensions.Interfaces;

namespace Calculation.UI.Views
{
    public partial class TimeDependentSolutionsView : Form, ITimeDependentSolutionsView
    {
        public TimeDependentSolutionsView(IEnumerable<PulsationSolutionItemModel> solutionItems)
        {
            Model = new SolutionsTimeDependentModel(solutionItems);
            InitializeComponent();
            Presenter = new TimeDependentSolutionsPresenter(this);

            occLayers.InitializeContexts();
            Context2D = occLayers;

            Load += Initialized;
            trbnt.ValueChanged += LayerChanged;
            btnRefresh.Click += RefreshClicked;
        }

        public SolutionsTimeDependentModel Model { get; set; }

        public void Bind()
        {
            trbnt.AddBinding(c => c.Value, Model, m => m.CurrentLayerIndex, DataSourceUpdateMode.OnPropertyChanged);
            tbStep.AddBinding(c => c.Text, Model, m => m.Step);
            trbnt.AddBinding(c => c.Maximum, Model, m => m.MaxIndex);
        }

        public void FillListView(List<SolutionItemColoredModel> solutionItems)
        {
            lvSolutions.Items.Clear();
            foreach (var solutionItemColored in solutionItems)
            {
                string label = string.Format("{1}", solutionItemColored.Item.Name, solutionItemColored.Item.Info);
                ListViewItem listViewItem = new ListViewItem(label);
                listViewItem.ForeColor = solutionItemColored.Color;
                lvSolutions.Items.Add(listViewItem);
            }
        }

        public int nt { get; set; }
        public event EventHandler Initialized;
        public TimeDependentSolutionsPresenter Presenter { get; private set; }
        public event EventHandler RefreshClicked;
        public event EventHandler LayerChanged;

        public IOpenGlContext2D Context2D { get; private set; }
    }
}
