namespace Calculation.Interfaces
{
    public interface ILayer1D
    {
        int nt { get; set; }

        double t { get; set; }

        double this[int i] { get; }

        double[] ToArray();
    }
}