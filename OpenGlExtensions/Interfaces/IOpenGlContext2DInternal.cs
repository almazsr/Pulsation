using OpenGlExtensions.Classes;

namespace OpenGlExtensions.Interfaces
{
    internal interface IOpenGlContext2DInternal : IOpenGlContextInternal
    {
        void DrawPoint(Point2D point);

        void DrawVector(Vector2D vector);

        void SetRasterPosition(Point2D position);
    }
}