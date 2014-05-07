using System.Collections.Generic;
using System.Collections.ObjectModel;
using Schemes.Interfaces;

namespace Schemes.TimeDependent1D
{
    public class Grid1D : IGrid1D
    {       
        public static Grid1D Build(double min, double max, int N)
        {
            double[] points = new double[N];
            double h = (max - min)/(N - 1);
            for (int i=0;i<N;i++)
            {
                points[i] = min + i*h;
            }
            return new Grid1D(points, h, min, max);
        }

        protected Grid1D(IList<double> list, double h, double min, double max)
            : base(list)
        {
            if (CheckParameters(list, h, min, max))
            {
                SetParameters(h, min, max);
            }
        }

        protected void SetParameters(double h, double min, double max)
        {            
            this.Min = min;
            this.Max = max;
            this.h = h;
        }

        protected bool CheckParameters(IList<double> list, double h, double min, double max)
        {
            return true;
        }

        public double h { get; private set; }

        public double this[int i]
        {
            get { throw new System.NotImplementedException(); }
        }

        public double Min { get; private set; }
        public double Max { get; private set; }

        public int N
        {
            get { return Count; }
        }
    }
}