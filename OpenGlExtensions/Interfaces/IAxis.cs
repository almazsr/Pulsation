using OpenGlExtensions.Enums;

namespace OpenGlExtensions.Interfaces
{
    public interface IAxis : IDrawable
    {
        IAxisDivisions Divisions { get; set; }

        double Min { get; set; }

        double Max { get; set; }

        AxisDirection Direction { get; }
    }
}