using OpenGlExtensions.Interfaces;

namespace Calculation.UI.Views
{
    public interface IChartView
    {
        IOpenGlContext2D Context2D { get; }
    }
}