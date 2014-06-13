using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Calculation.UI.Models;
using Calculation.UI.Presenters;
using OpenGlExtensions.Interfaces;

namespace Calculation.UI.Views
{
    public partial class SolutionsView : Form, ISolutionsView
    {
        public SolutionsView(List<PulsationSolutionItemModel> solutionItems, bool comparison = false)
        {
            Model = new SolutionsCurvesModel(solutionItems);
            InitializeComponent();

            Presenter = comparison ? new SolutionsComparisonPresenter(this) : new SolutionsPresenter(this);

            occLayers.InitializeContexts();
            Context2D = occLayers;

            Load += Initialized;
        }

        public SolutionsCurvesModel Model { get; set; }

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

        public SolutionsPresenter Presenter { get; set; }
        public IOpenGlContext2D Context2D { get; private set; }

        public event EventHandler Initialized;
    }
}
