using System.Collections.Generic;

namespace Calculation.Interfaces
{
    public interface IAccessSolutionContext : ISolutionContext
    {
        IList<ISolution1D> GetSolutions();

        ISolution1D GetSolution(int solutionId);

        ILayer1D GetLayer(int solutionId, int nt);

        IList<ILayer1D> GetAllLayers(int solutionId, int count);

        List<ILayer1D> GetLayers(int solutionId, int fromTimeIndex, int count);

        object GetPhysicalData(int solutionId);

        IGrid1D GetGrid(int solutionId);

        void DeleteSolution(int id);
    }
}