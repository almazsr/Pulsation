namespace Calculation.Interfaces
{
    public interface IGrid1D
    {
        double Min { get; }
        double Max { get; }
        int N { get; }
        double h { get; }

        double this[int i] { get; }
    }
}