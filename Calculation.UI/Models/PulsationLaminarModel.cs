using System;

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

        public const double TimeMax = 2*Math.PI;

        public int NTime
        {
            get { return AppSettings.Default.NTime; }
            set { AppSettings.Default.NTime = value; }
        }

        public double dAngle
        {
            get { return AppSettings.Default.dAngle; }
            set { AppSettings.Default.dAngle = value; }
        }

        public int ProgressMax
        {
            get { return (Exact ? 1 : 0) + (CrankNikolson ? 1 : 0) + (Implicit ? 1 : 0); }
        }

        public int NGrid
        {
            get { return AppSettings.Default.NGrid; }
            set { AppSettings.Default.NGrid = value; }
        }

        public bool Exact
        {
            get { return AppSettings.Default.Exact; }
            set { AppSettings.Default.Exact = value; }
        }

        public bool CrankNikolson {
            get { return AppSettings.Default.CrankNikolson; }
            set { AppSettings.Default.CrankNikolson = value; }
        }

        public bool Implicit
        {
            get { return AppSettings.Default.Implicit; }
            set { AppSettings.Default.Implicit = value; }
        }
    }
}