using System.Collections.Generic;
using System.Linq;

namespace OpenGlExtensions.Classes
{
    public sealed class Curve2D : Line2D
    {
        public Curve2D()
        {
            Points = new List<Point2D>();
        }

        public Curve2D(IEnumerable<Point2D> points)
        {
            Points = points.ToList();
        }

        public Curve2D(double[] x, double[] y)
            : this()
        {
            for (int i = 0; i < x.Length; i++)
            {
                Add(x[i], y[i]);
            }
        }

        public void Add(Point2D point)
        {
            Points.Add(point);
        }

        public void Add(double x, double y)
        {
            Add(new Point2D(x, y));
        }

        public void Clear()
        {
            Points.Clear();
        }

        public void Remove(Point2D point)
        {
            Points.Remove(point);
        }
    }
}