namespace Schemes.Interfaces
{
    public interface IFactory
    {
        IGrid1D CreateGrid(double min, double max, int N);

        ITimeDependentSolution1D CreateSolution(IGrid1D grid, double dt);

        ILayer1D CreateLayer(double[] values, int timeIndex, double time);
    }
}