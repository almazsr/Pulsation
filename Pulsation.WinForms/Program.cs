using System;
using System.Windows.Forms;
using Pulsation.UI.Views;

namespace Pulsation.UI
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new PulsationLaminarView());
        }
    }
}
