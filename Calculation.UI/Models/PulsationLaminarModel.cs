using System;
using System.ComponentModel;

namespace Calculation.UI.Models
{
    public class PulsationLaminarModel
    {
        public double s
        {
            get { return AppSettings.Default.s; }
            set { AppSettings.Default.s = value; }
        }

        public double Re
        {
            get { return AppSettings.Default.Re; }
            set { AppSettings.Default.Re = value; }
        }

        public int NTime
        {
            get { return AppSettings.Default.NTime; }
            set { AppSettings.Default.NTime = value; }
        }

        public int NGrid
        {
            get { return AppSettings.Default.NGrid; }
            set { AppSettings.Default.NGrid = value; }
        }
    }
}