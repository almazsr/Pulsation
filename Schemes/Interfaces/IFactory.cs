namespace Calculation.Interfaces
{
    public interface IFactory
    {
        IGrid1D CreateGrid(double min, double max, int N);

        ISolution1D CreateSolution(IGrid1D grid, double timeStep);
    }
}