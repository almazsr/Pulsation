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
            Bind();
        }        

        public PulsationLaminarModel Model { get; set; }

        public void Bind()
        {
            tbs.AddBinding(c => c.Text, Model, m => m.s);
            tbRe.AddBinding(c => c.Text, Model, m => m.Re);
            tbNGrid.AddBinding(c => c.Text, Model, m => m.NGrid);
            tbNTime.AddBinding(c => c.Text, Model, m => m.NTime);
        }

        public PulsationLaminarPresenter Presenter { get; private set; }
        public int Progress { get; set; }
        public event EventHandler ShowClicked;
        public event EventHandler SolveClicked;
        public event EventHandler CancelClicked;
    }
}
