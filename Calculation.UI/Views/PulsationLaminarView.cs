using System;
using System.Windows.Forms;
using Calculation.UI.Helpers;
using Calculation.UI.Presenters;
using Pulsation.Models;

namespace Calculation.UI.Views
{
    public partial class PulsationLaminarView : Form, IPulsationLaminarView
    {
        public PulsationLaminarView()
        {
            Model = new PulsationModel();
            Presenter = new PulsationPresenter(this);

            InitializeComponent();

            Load += Initialized;
            btnSolve.Click += SolveClicked;
        }        

        public PulsationModel Model { get; set; }

        public void Bind()
        {
            tbs.AddBinding(c => c.Text, Model, m => m.s);
            tbdAngle.AddBinding(c => c.Text, Model, m => m.dtDeg);
            tbRe.AddBinding(c => c.Text, Model, m => m.Re);
            tbNGrid.AddBinding(c => c.Text, Model, m => m.GridN);
            tbNTime.AddBinding(c => c.Text, Model, m => m.TimeN);
            tbbeta.AddBinding(c => c.Text, Model, m => m.beta);
            tbepsilon.AddBinding(c => c.Text, Model, m => m.epsilon);
            tbH1.AddBinding(c => c.Text, Model, m => m.H1);
            tbH2.AddBinding(c => c.Text, Model, m => m.H2);
            tbH3.AddBinding(c => c.Text, Model, m => m.H3);
            cbExplicit.AddBinding(c => c.Checked, Model, m => m.Explicit);
            cbIsComplexMode.AddBinding(c => c.Checked, Model, m => m.IsComplexMode);
            cbTurbulent.AddBinding(c => c.Checked, Model, m => m.Turbulent);
            cbCrankNikolson.AddBinding(c=>c.Checked, Model, m=>m.CrankNikolson, DataSourceUpdateMode.OnPropertyChanged);
            cbExact.AddBinding(c => c.Checked, Model, m => m.Exact, DataSourceUpdateMode.OnPropertyChanged);
            cbImplicit.AddBinding(c => c.Checked, Model, m => m.Implicit, DataSourceUpdateMode.OnPropertyChanged);
        }

        public event EventHandler ShowClicked;
        public event EventHandler SolveClicked;
        public event EventHandler Initialized;
        public PulsationPresenter Presenter { get; private set; }
    }
}
