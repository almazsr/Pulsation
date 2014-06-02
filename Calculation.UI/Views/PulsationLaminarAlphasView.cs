using System;
using System.Windows.Forms;
using Calculation.UI.Helpers;
using Calculation.UI.Models;
using Calculation.UI.Presenters;

namespace Calculation.UI.Views
{
    public partial class PulsationLaminarAlphasView : Form, IPulsationLaminarAlphasView
    {
        public PulsationLaminarAlphasView(SolutionItemModel solutionItem)
        {
            InitializeComponent();
            Model = new PulsationLaminarAlphasModel {SolutionId = solutionItem.Id};
            btnSolve.Click += SolveClicked;
            Load += Initialized;
            Presenter = new PulsationLaminarAlphasPresenter(this);
        }

        public PulsationLaminarAlphasModel Model { get; set; }

        public event EventHandler SolveClicked;

        public void Progress(int percentage)
        {

        }

        public event EventHandler Initialized;
        public PulsationLaminarAlphasPresenter Presenter { get; private set; }

        private void btnSolve_Click(object sender, EventArgs e)
        {
            Model.Name = "123";
        }
    }
}
