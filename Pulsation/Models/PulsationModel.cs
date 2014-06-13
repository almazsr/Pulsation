using System;
using Calculation.Classes.Data;

namespace Pulsation.Models
{
    public class PulsationModel
    {
        #region Physics
        [Parameter("Режим течения")]
        public string FlowMode { get; set; }

        [Parameter("r0*Sqrt[omega/nu]")]
        public double s
        {
            get { return PulsationSettings.Default.s; }
            set { PulsationSettings.Default.s = value; }
        }

        [Parameter("u'/u0")]
        public double beta
        {
            get { return PulsationSettings.Default.beta; }
            set { PulsationSettings.Default.beta = value; }
        }

        [Parameter("u0*r0/nu")]
        public double Re
        {
            get { return PulsationSettings.Default.Re; }
            set { PulsationSettings.Default.Re = value; }
        }

        [Parameter("r0/x0")]
        public double epsilon
        {
            get { return PulsationSettings.Default.epsilon; }
            set { PulsationSettings.Default.epsilon = value; }
        }

        #region Hi

        [Parameter("s^2")]
        public double H1
        {
            get { return PulsationSettings.Default.H1; }
            set { PulsationSettings.Default.H1 = value; }
        }

        [Parameter("Re*beta^2")]
        public double H2
        {
            get { return PulsationSettings.Default.H2; }
            set { PulsationSettings.Default.H2 = value; }
        }

        [Parameter("epsilon*Re")]
        public double H3
        {
            get { return PulsationSettings.Default.H3; }
            set { PulsationSettings.Default.H3 = value; }
        }
        #endregion

        #endregion

        #region Solver
        [Parameter("Решатель")]
        public string SolverType { get; set; }

        [Parameter("Схема")]
        public string SchemeType { get; set; }

        #endregion

        #region Grid
        [Parameter("a")]
        public double GridMin
        {
            get { return 0; }
        }
        [Parameter("b")]
        public double GridMax
        {
            get { return 1; }
        }

        [Parameter("GridN")]
        public int GridN
        {
            get { return PulsationSettings.Default.NGrid; }
            set { PulsationSettings.Default.NGrid = value; }
        }
        #endregion

        #region Time

        [Parameter("Period")]
        public double Period
        {
            get { return 2*Math.PI; }
        }

        [Parameter("TimeMax")]
        public double TimeMax
        {
            get { return 100 * Period; }
        }

        [Parameter("TimeN")]
        public int TimeN
        {
            get { return PulsationSettings.Default.NTime; }
            set { PulsationSettings.Default.NTime = value; }
        }

        [Parameter("dt(deg)")]
        public double dtDeg
        {
            get { return PulsationSettings.Default.dAngle; }
            set { PulsationSettings.Default.dAngle = value; }
        }

        [Parameter("dt")]
        public double dt
        {
            get { return dtDeg / 180 * Math.PI; }
        }
        #endregion

        public bool IsComplexMode
        {
            get { return PulsationSettings.Default.IsComplexMode; }
            set { PulsationSettings.Default.IsComplexMode = value; }
        }

        public bool Exact
        {
            get { return PulsationSettings.Default.Exact; }
            set { PulsationSettings.Default.Exact = value; }
        }

        public bool CrankNikolson 
        {
            get { return PulsationSettings.Default.CrankNikolson; }
            set { PulsationSettings.Default.CrankNikolson = value; }
        }

        public bool Turbulent
        {
            get { return PulsationSettings.Default.Turbulent; }
            set { PulsationSettings.Default.Turbulent = value; }
        }

        public bool Implicit
        {
            get { return PulsationSettings.Default.Implicit; }
            set { PulsationSettings.Default.Implicit = value; }
        }

        public bool Explicit
        {
            get { return PulsationSettings.Default.Explicit; }
            set { PulsationSettings.Default.Explicit = value; }
        }
    }
}