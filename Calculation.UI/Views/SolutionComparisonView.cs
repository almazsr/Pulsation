using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Calculation.UI.Models;
using Calculation.UI.Presenters;
using OpenGlExtensions.Interfaces;

namespace Calculation.UI.Views
{
    public partial class SolutionsComparisonView : Form, ISolutionsComparisonView
    {
        public SolutionsComparisonView(List<SolutionItemModel> solutionItems)
        {
            Model = new PulsationLaminarSolutionsModel(solutionItems);
            InitializeComponent();

            Presenter = new PulsationLaminarComparisonPresenter(this);

            occLayers.InitializeContexts();
            Context2D = occLayers;

            Load += Initialized;
        }

        public PulsationLaminarSolutionsModel Model { get; set; }

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

        public PulsationLaminarComparisonPresenter Presenter { get; set; }
        public event EventHandler Initialized;
        public IOpenGlContext2D Context2D { get; private set; }
    }
}
