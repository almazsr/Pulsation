using Calculation.Classes.Data;
using Calculation.Helpers;

namespace Pulsation.Models
{
    public class PulsationData
    {   
        public PulsationData(){}

        public PulsationData(PulsationModel model)
        {
            ObjectHelper.Copy(model, this, typeof(ParameterAttribute));
        }

        #region Physics
        [Parameter("Режим течения")]
        public string FlowMode { get; set; }

        [Parameter("r0*Sqrt[omega/nu]")]
        public double s { get; set; }

        [Parameter("u'/u0")]
        public double beta { get; set; }

        [Parameter("u0*r0/nu")]
        public double Re { get; set; }

        [Parameter("r0/x0")]
        public double epsilon { get; set; }

        #region Hi

        [Parameter("s^2")]
        public double H1 { get; set; }

        [Parameter("Re*beta^2")]
        public double H2 { get; set; }

        [Parameter("epsilon*Re")]
        public double H3 { get; set; }
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
        public double GridMin { get; set; }
        [Parameter("b")]
        public double GridMax { get; set; }

        [Parameter("GridN")]
        public int GridN { get; set; }
        #endregion

        #region Time

        [Parameter("TimeMax")]
        public double TimeMax { get; set; }

        [Parameter("TimeN")]
        public int TimeN { get; set; }

        [Parameter("Period")]
        public double Period { get; set; }

        [Parameter("dt(deg)")]
        public double dtDeg { get; set; }

        [Parameter("dt")]
        public double dt { get; set; }
        #endregion
    }
}