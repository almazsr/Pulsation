using Calculation.Interfaces;

namespace Calculation.Classes
{
    public class DbFactory : IFactory
    {
        public IGrid1D CreateGrid(double min, double max, int N)
        {
            return new DbGrid1D
                       {
                           Min = min,
                           Max = max,
                           N = N,
                           h = (max - min)/N,
                           Name = string.Format("[{0:0.##}, {1:0.##}]({2})", min, max, N)
                       };
        }

        public ITimeDependentSolution1D CreateSolution(IGrid1D grid, double dt)
        {
            return new DbTimeDependentSolution1D
                       {
                           Grid = grid,
                           dt = dt
                       };
        }

        public ILayer1D CreateLayer(double[] values, int timeIndex, double time)
        {
            return new DbLayer1D(values)
                       {
                           Time = time,
                           TimeIndex = timeIndex
                       };
        }
    }
}