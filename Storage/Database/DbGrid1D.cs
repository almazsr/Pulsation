using Calculation.Interfaces;

namespace Storage.Database
{
    public partial class DbGrid1D : IGrid1D
    {
        public double this[int i]
        {
            get { return i * h; }
        }
    }
}