using System;
using System.Drawing;
using OpenGlExtensions.Enums;
using OpenGlExtensions.Interfaces;

namespace OpenGlExtensions.Classes
{
    public class AxisDivisions2D : Shape2D, IAxisDivisions
    {
        internal AxisDivisions2D(Axis2D axis)
        {
            Context2D = axis.Context2D;
            Axis = axis;
            NumberFormat = "0.#####";
            Count = 10;
            Color = Color.Black;
            NumbersVisible = true;
            DivisionsVisible = false;
        }

        protected override void Draw()
        {
            double current = Axis.Min;
            double axisLength = Axis.Max - Axis.Min;
            double h = axisLength/Count;
            double size = Math.Min(DivisionPersentSize*axisLength, 0.001);
            for (int i = 0; i < Count; i++)
            {
                current += h;
                if (current == 0 && 
                    Axis.Direction == AxisDirection.Y)
                {
                    continue;                    
                }
                double x, y, nx, ny;
                string label;
                switch (Axis.Direction)
                {
                    case AxisDirection.X:
                        {
                            x = current;
                            nx = 1;
                            ny = -1;
                            y = size;
                            label = x.ToString(NumberFormat);
                        }
                        break;
                    case AxisDirection.Y:
                        {
                            y = current;
                            x = size;
                            nx = -1;
                            ny = 1;
                            label = y.ToString(NumberFormat);
                        }
                        break;
                    default:
                        throw new NotImplementedException();
                }
                if (DivisionsVisible)
                {
                    Context2DInternal.DrawVector(new Vector2D(nx*x, ny*y, x, y));
                }
                if (NumbersVisible)
                {
                    Context2DInternal.SetRasterPosition(new Point2D(x, y));
                    Context2DInternal.DrawText(label);
                }
            }
        }

        public double DivisionPersentSize { get; set; }
        public int Count { get; set; }
        public bool NumbersVisible { get; set; }
        public bool DivisionsVisible { get; set; }
        public string NumberFormat { get; set; }
        public IAxis Axis { get; private set; }
    }
}