using System.Collections.Generic;

namespace Calculation.Interfaces
{
    public interface IAccessSolutionContext : ISolutionContext
    {
        List<ISolution1D> GetSolutions();

        ISolution1D GetSolution(int solutionId);

        ILayer1D GetLayer(int solutionId, int nt);

        List<ILayer1D> GetSeparatedLayers(int solutionId, int separateCount);

        List<ILayer1D> GetSeparatedLayers(int solutionId, int fromTimeIndex, int count, int separateCount);

        List<ILayer1D> GetLayers(int solutionId, int fromTimeIndex, int count);

        object GetPhysicalData(int solutionId);

        IGrid1D GetGrid(int solutionId);

        void DeleteSolution(int id);
    }
}