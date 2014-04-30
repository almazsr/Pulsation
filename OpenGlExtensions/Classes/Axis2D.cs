using System;
using System.Collections.Generic;
using OpenGlExtensions.Enums;
using OpenGlExtensions.Interfaces;

namespace OpenGlExtensions.Classes
{
    public class Axis2D : Line2D, IAxis
    {
        internal Axis2D(AxisDirection direction, DrawingArea2D drawingArea2D) 
        {
            Direction = direction;
            Context2D = drawingArea2D.Context2D;
            Divisions = new AxisDivisions2D(this);
            Min = DefaultMin;
            Max = DefaultMax;
        }

        public const double DefaultMin = -10;
        public const double DefaultMax = 10;

        #region Methods
        protected override void Draw()
        {
            base.Draw();
            if (Divisions.Visible)
            {
                (Divisions2D as IDrawableInternal).Draw();
            }
        } 
        #endregion

        #region Properties

        public override List<Point2D> Points
        {
            get
            {
                switch (Direction)
                {
                    case AxisDirection.X:
                        return new List<Point2D>
                                   {
                                       new Point2D { X = Min, Y = 0},
                                       new Point2D { X = Max, Y = 0 }
                                   };
                    case AxisDirection.Y:
                        return new List<Point2D>
                                   {
                                       new Point2D { X = 0, Y = Min },
                                       new Point2D { X = 0, Y = Max }
                                   };
                    default:
                        throw new NotImplementedException();
                }
            }
        }

        public IAxisDivisions Divisions { get; set; }

        protected AxisDivisions2D Divisions2D
        {
            get { return Divisions as AxisDivisions2D; }
        }

        public double Min { get; set; }
        public double Max { get; set; }

        public AxisDirection Direction { get; private set; } 
        #endregion
    }
}