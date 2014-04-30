using System.Collections.Generic;
using OpenGlExtensions.Enums;
using System.Drawing;
using OpenGlExtensions.Interfaces;


namespace OpenGlExtensions.Classes
{
    public class DrawingArea2D : Shape2D, IDrawingArea
    {
        public DrawingArea2D(IOpenGlContext2D context2D)
        {
            Objects = new List<IDrawable>();
            Visible = true;
            Color = Color.White;
            Context2D = context2D;
            XAxis = new Axis2D(AxisDirection.X, this);
            YAxis = new Axis2D(AxisDirection.Y, this);
        }

        public IAxis XAxis { get; set; }
        public IAxis YAxis { get; set; }

        public List<IDrawable> Objects { get; private set; }

        protected void DrawAxis(IAxis axis)
        {
            var drawableInternal = axis as IDrawableInternal;
            if (drawableInternal != null)
            {
                drawableInternal.Draw();
            }
        }

        protected override void Draw()
        {
            if (Visible)
            {
                DrawAxis(XAxis);
                DrawAxis(YAxis);
                foreach (IDrawableInternal drawable in Objects)
                {
                    drawable.Draw();
                }
            }
        }
    }
}