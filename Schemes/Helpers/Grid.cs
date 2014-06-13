namespace Calculation.Helpers
{
    public class Grid
    {
        public static Grid Create(double min, double max, int N)
        {
            if ((min == default(double) && max == default(double)) || N <= 1)
            {
                return null;
            }
            return new Grid(min, max, N);
        }       
 
        public Grid(double min, double max, int N)
        {
            this.Min = min;
            this.Max = max;
            this.N = N;
            this.h = (max - min) / (N - 1);
            this.Values = new double[N];
            for (int i = 0; i < N; i++)
            {
                this.Values[i] = min + i * h;
            }
        }

        public double this[int i]
        {
            get { return Values[i]; }
        }

        public double[] Values { get; private set; }

        public double Min { get; private set; }
        public double Max { get; private set; }
        public double h { get; private set; }
        public int N { get; private set; }
    }
}