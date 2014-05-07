using Schemes.Helpers;
using Schemes.Interfaces;

namespace Schemes.Database
{
    public partial class DbLayer1D : ILayer1D
    {
        public DbLayer1D(double[] values)
        {
            Values = values;
            Data = Convert.ToBytes(values);
        }

        public DbLayer1D(byte[] data)
        {
            Data = data;
            Values = Convert.ToDoubles(data);
        }     

        public double this[int i]
        {
            get { return Values[i]; }
        }

        internal double[] Values { get; set; }
    }
}