using System.Collections.Generic;
using OpenGlExtensions.Classes;
using OpenGlExtensions.Interfaces;
using Tao.OpenGl;

namespace OpenGlExtensions
{
    public class OpenGlChartControl : OpenGlControlBase, IOpenGlContext2D, IOpenGlContext2DInternal
    {
        public OpenGlChartControl()
        {
            DrawingArea = new DrawingArea2D(this);
        }

        protected DrawingArea2D DrawingArea2D
        {
            get { return DrawingArea as DrawingArea2D; }
        }

        public void ClearArea()
        {
            DrawingArea.Objects.Clear();            
        }

        public void AddShape(Shape2D shape)
        {
            shape.Context2D = this;
            DrawingArea.Objects.Add(shape);
        }

        public void AddShapes(IEnumerable<Shape2D> shapes)
        {
            foreach (Shape2D shape in shapes)
            {
                AddShape(shape);
            }
        }

        public void SetAreaBoundaries(double xMin, double xMax, double yMin, double yMax, double persentEpsilon = 0.01)
        {
            double xMargin = (xMax - xMin) * persentEpsilon;
            double yMargin = (yMax - yMin) * persentEpsilon;
            DrawingArea2D.XAxis.Min = xMin - xMargin;
            DrawingArea2D.XAxis.Max = xMax + xMargin;
            DrawingArea2D.YAxis.Min = yMin-yMargin;
            DrawingArea2D.YAxis.Max = yMax+yMargin;
            SetView();            
        }

        #region Draw methods

        internal void DrawVector(Vector2D vector)
        {
            BeginLines();
            DrawPoint(vector.A);
            DrawPoint(vector.B);
            End();
        }

        public void SetRasterPosition(Point2D position)
        {
            Gl.glRasterPos2d(position.X, position.Y);
        }

        internal void DrawVector(double xA, double yA, double xB, double yB)
        {
            BeginLines();
            DrawPoint(xA, yA);
            DrawPoint(xB, yB);
            End();
        }

        internal void DrawPoint(double x, double y)
        {
            Gl.glVertex2d(x, y);
        }

        internal void DrawPoint(Point2D point)
        {
            DrawPoint(point.X, point.Y);
        }

        void IOpenGlContext2DInternal.DrawVector(Vector2D vector)
        {
            DrawVector(vector);
        }

        internal void DrawText(Point2D position, string text)
        {
            SetRasterPosition(position);
            DrawText(text);
        }
        #endregion

        void IOpenGlContext2DInternal.DrawPoint(Point2D point)
        {
            DrawPoint(point);
        }

        protected override void SetView()
        {
            Gl.glMatrixMode(Gl.GL_PROJECTION);
            Gl.glLoadIdentity();
            Glu.gluOrtho2D(
                DrawingArea2D.XAxis.Min,
                DrawingArea2D.XAxis.Max,
                DrawingArea2D.YAxis.Min,
                DrawingArea2D.YAxis.Max);
            Gl.glMatrixMode(Gl.GL_MODELVIEW);
            Gl.glLoadIdentity();
        }
    }
}