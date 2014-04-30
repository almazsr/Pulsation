using System.Drawing;

namespace OpenGlExtensions.Interfaces
{
    public interface IDrawable
    {
        Color Color { get; set; }

        bool Visible { get; set; }
    }
}