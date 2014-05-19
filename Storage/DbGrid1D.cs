using Calculation.Interfaces;

namespace Storage
{
    public partial class DbGrid1D : IGrid1D
    {
        public DbGrid1D(double min, double max, int N)
        {
            this.Max = max;
            this.Min = min;
            this.N = N;
            this.h = (max - min) / N;
            this.Name = string.Format("[{0:0.##}, {1:0.##}]({2})", min, max, N);
        }

        public double this[int i]
        {
            get { return Min + i*h; }
        }
    }
}