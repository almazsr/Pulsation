using System.Drawing;

namespace OpenGlExtensions.Interfaces
{
    internal interface IOpenGlContextInternal
    {
        void BeginLines();
        void Begin(int mode);
        void End();
        void SetColor(Color color);        
        void DrawText(string text);
    }
}