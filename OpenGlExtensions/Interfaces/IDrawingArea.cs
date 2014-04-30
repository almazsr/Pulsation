using System.Collections.Generic;

namespace OpenGlExtensions.Interfaces
{
    public interface IDrawingArea : IDrawable
    {
        List<IDrawable> Objects { get; }
    }
}