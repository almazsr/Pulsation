namespace Calculation.Interfaces
{
    public interface ILayer1D
    {
        int TimeIndex { get; set; }

        double Time { get; set; }

        double this[int i] { get; }
    }
}