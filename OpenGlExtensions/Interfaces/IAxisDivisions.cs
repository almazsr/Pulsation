namespace OpenGlExtensions.Interfaces
{
    public interface IAxisDivisions : IDrawable
    {
        double DivisionPersentSize { get; set; }

        int Count { get; set; }

        bool NumbersVisible { get; set; }

        bool DivisionsVisible { get; set; }

        IAxis Axis { get; }
    }
}