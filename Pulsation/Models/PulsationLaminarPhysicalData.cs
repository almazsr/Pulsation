namespace Pulsation.Models
{
    public class PulsationLaminarPhysicalData
    {
        #region Constructors
        public PulsationLaminarPhysicalData(double Re = DefaultRe, double s = Defaults)
        {
            this.s = s;
            this.Re = Re;
        } 
        #endregion

        #region Constants
        public const double Defaults = 2.849;
        public const double DefaultRe = 1;
        #endregion

        #region Properties

        public double s { get; set; } 
        public double Re { get; set; } 
        #endregion 
    }
}