namespace OpenGlExtensions.Classes
{
    public class Vector2D
    {
        public Vector2D(Point2D a, Point2D b)
        {
            A = a;
            B = b;
        }

        public Vector2D(double xA, double yA, double xB, double yB) : 
            this(new Point2D(xA, yA), new Point2D(xB, yB))
        {
            
        }

        public Point2D A { get; set; }

        public Point2D B { get; set; }
    }
}