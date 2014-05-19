using System.Collections.Generic;

namespace Calculation.Interfaces
{
    public interface IAccessSolutionContext : ISolutionContext
    {
        IList<ISolution1D> GetSolutions();

        ISolution1D GetSolution(object key);
        
        ILayer1D GetLayer(ISolution1D solution, int nt);

        IList<ILayer1D> GetLayers(ISolution1D solution, int count);

        object GetPhysicalData(ISolution1D solution);

        void StartSolution(ISolution1D solution);

        void NextTimeSolution(ISolution1D solution);

        IGrid1D GetGrid(ISolution1D solution);
    }
}