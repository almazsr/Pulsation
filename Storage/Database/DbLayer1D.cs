using Calculation.Interfaces;

namespace Storage.Database
{
    public partial class DbLayer1D : ILayer1D
    {
        public double this[int i]
        {
            get { return Values[i]; }
        }

        internal double[] Values { get; set; }
    }
}