using System.Collections.Generic;
using OpenGlExtensions.Classes;

namespace OpenGlExtensions.Interfaces
{
    public interface IOpenGlContext2D : IOpenGlContext
    {
        void ClearArea();

        void AddShape(Shape2D shape);

        void AddShapes(IEnumerable<Shape2D> shapes);

        void SetAreaBoundaries(double xMin, double xMax, double yMin, double yMax, double persentMargin);
    }
}