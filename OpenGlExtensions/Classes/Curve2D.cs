using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace OpenGlExtensions.Classes
{
    public sealed class Curve2D : Line2D
    {
        public Curve2D()
        {
            Points = new List<Point2D>();
        }

        public Curve2D(Color color)
            : this()
        {
            Color = color;
        }

        public Curve2D(IEnumerable<Point2D> points, Color color)
        {
            Points = points.ToList();
            Color = color;
        }

        public Curve2D(double[] x, double[] y, Color color)
            : this(color)
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