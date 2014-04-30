using System.Collections.Generic;
using System.Drawing;

namespace OpenGlExtensions.Classes
{
    public abstract class Line2D : Shape2D
    {
        protected Line2D()
        {
            Color = Color.Black;
        }

        #region Properties
        public virtual List<Point2D> Points { get; protected set; }
        #endregion

        protected override void Draw()
        {
            Context2DInternal.BeginLines();            
            for (int i = 1; i < Points.Count; i++)
            {
                Context2DInternal.DrawPoint(Points[i - 1]);
                Context2DInternal.DrawPoint(Points[i]);
            }
            Context2DInternal.End();
        }
    }
}