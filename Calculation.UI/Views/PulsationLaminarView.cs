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
            cbCrankNikolson.AddBinding(c=>c.Checked, Model, m=>m.CrankNikolson, DataSourceUpdateMode.OnPropertyChanged);
            cbExact.AddBinding(c => c.Checked, Model, m => m.Exact, DataSourceUpdateMode.OnPropertyChanged);
            cbImplicit.AddBinding(c => c.Checked, Model, m => m.Implicit, DataSourceUpdateMode.OnPropertyChanged);
        }

        public PulsationLaminarPresenter Presenter { get; private set; }
        public int Progress { get; set; }
        public event EventHandler ShowClicked;
        public event EventHandler SolveClicked;
        public event EventHandler Initialized;

        private void PulsationLaminarView_Load(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
