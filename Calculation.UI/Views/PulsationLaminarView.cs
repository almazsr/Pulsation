using System;
using System.Windows.Forms;
using Calculation.UI.Helpers;
using Calculation.UI.Presenters;
using PulsationLaminarModel = Calculation.UI.Models.PulsationLaminarModel;

namespace Calculation.UI.Views
{
    public partial class PulsationLaminarView : Form, IPulsationLaminarView
    {
        public PulsationLaminarView()
        {
            Model = new PulsationLaminarModel();
            Presenter = new PulsationLaminarPresenter(this);

            InitializeComponent();

            Load += Initialized;
            btnSolve.Click += SolveClicked;
        }        

        public PulsationLaminarModel Model { get; set; }

        public void Bind()
        {
            tbs.AddBinding(c => c.Text, Model, m => m.s);
            tbdAngle.AddBinding(c => c.Text, Model, m => m.dAngle);
            tbRe.AddBinding(c => c.Text, Model, m => m.Re);
            tbNGrid.AddBinding(c => c.Text, Model, m => m.NGrid);
            tbNTime.AddBinding(c => c.Text, Model, m => m.NTime);
            tbbeta.AddBinding(c => c.Text, Model, m => m.beta);
            cbCrankNikolson.AddBinding(c=>c.Checked, Model, m=>m.CrankNikolson, DataSourceUpdateMode.OnPropertyChanged);
            cbExact.AddBinding(c => c.Checked, Model, m => m.Exact, DataSourceUpdateMode.OnPropertyChanged);
            cbImplicit.AddBinding(c => c.Checked, Model, m => m.Implicit, DataSourceUpdateMode.OnPropertyChanged);
            progressBar1.AddBinding(c => c.Maximum, Model, m => m.ProgressMax);
            cbTimeMaxOnly.AddBinding(c => c.Checked, Model, m => m.TimeMaxOnly);
        }

        public event EventHandler ShowClicked;
        public event EventHandler SolveClicked;
        public event EventHandler Initialized;
        public PulsationLaminarPresenter Presenter { get; private set; }

        public void Progress(int percentage)
        {
            progressBar1.Value = percentage;            
        }

        private void PulsationLaminarView_Load(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
