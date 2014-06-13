using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Calculation.UI.Presenters;
using Calculation.UI.Views;
using Pulsation;

namespace Calculation.UI
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.ApplicationExit += Application_ApplicationExit;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new SolutionListView());
        }

        static void Application_ApplicationExit(object sender, EventArgs e)
        {
            PulsationSettings.Default.Save();
        }
    }
}
