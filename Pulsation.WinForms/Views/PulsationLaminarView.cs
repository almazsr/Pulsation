using System;
using System.Windows.Forms;
using OpenGlExtensions.Interfaces;
using Pulsation.UI.Helpers;
using Pulsation.UI.Presenters;
using Pulsation.UI.ViewModels;

namespace Pulsation.UI.Views
{
    public partial class PulsationLaminarView : Form, IPulsationLaminarView
    {
        public PulsationLaminarView()
        {
            Presenter = new PulsationLaminarPresenter(this);

            InitializeComponent();
            occChart.InitializeContexts();

            AddBindings();

            btnSolve.Click += SolveClicked;
        }

        public void AddBindings()
        {
            tbdAngle.AddBinding(m => m.Text, ViewModel.CalculationData, m => m.dAngle);
            tbNGrid.AddBinding(m => m.Text, ViewModel.CalculationData, m => m.NGrid);
            tbdt.AddBinding(m => m.Text, ViewModel.CalculationData, m => m.dt);
            tbRe.AddBinding(m => m.Text, ViewModel.PhysicalData, m => m.Re);
            tbs.AddBinding(m => m.Text, ViewModel.PhysicalData, m => m.s);
            cbExactSolution.AddBinding(m => m.Checked, ViewModel, m => m.ExactSolutionVisible, DataSourceUpdateMode.OnPropertyChanged);
            cbCrankNikolsonSolution.AddBinding(m => m.Checked, ViewModel, m => m.CrankNikolsonSchemeSolutionVisible, DataSourceUpdateMode.OnPropertyChanged);
            cbImplicitScheme.AddBinding(m => m.Checked, ViewModel, m => m.ImplicitSchemeSolutionVisible, DataSourceUpdateMode.OnPropertyChanged);
            trbLayer.AddBinding(m => m.Maximum, ViewModel.CalculationData, m => m.NTime, DataSourceUpdateMode.OnPropertyChanged);
            trbLayer.AddBinding(m => m.Value, ViewModel, m => m.CurrentLayerIndex, DataSourceUpdateMode.OnPropertyChanged);
            tbAngle.AddBinding(m => m.Text, ViewModel, m => m.Angle);
            trbLayer.AddBinding(m => m.Visible, ViewModel, m => m.Solved, DataSourceUpdateMode.OnPropertyChanged);
        }

        public PulsationLaminarSolutionViewModel ViewModel { get; set; }

        public IOpenGlContext2D Context2D
        {
            get { return occChart; }
        }

        public PulsationLaminarPresenter Presenter { get; private set; }

        public void ShowLayerTrackBar()
        {
            trbLayer.Visible = true;
        }

        public event EventHandler SolveClicked;
    }
}
