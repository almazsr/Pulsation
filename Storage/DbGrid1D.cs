using Calculation.Interfaces;

namespace Calculation.Database
{
    public partial class DbGrid1D : IGrid1D
    {
        public DbGrid1D(double min, double max, int N)
        {
            this.Max = max;
            this.Min = min;
            this.N = N;
            this.h = (max - min)/(N - 1);
            this.Name = string.Format(NameFormat, min, max, N);
        }

        public static string NameFormat = "[{0:0.##}, {1:0.##}]({2})";

        public double this[int i]
        {
            get { return Min + i*h; }
        }

        public double[] ToArray()
        {
            double[] result = new double[N];
            for (int i=0;i<N;i++)
            {
                result[i] = this[i];
            }
            return result;
        }
    }
}