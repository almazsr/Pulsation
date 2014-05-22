using System;

namespace Calculation.Interfaces
{
    public interface ISolutionContext : IDisposable
    {
        IGrid1D CreateGrid(double min, double max, int N);

        ISolution1D CreateNumericSolution(IGrid1D grid, object physicalData, Type solverType);
        ISolution1D CreateNumericTimeDependentSolution(IGrid1D grid, object physicalData, double dt, Type solverType);
        ISolution1D CreateExactSolution(IGrid1D grid, object physicalData);
        ISolution1D CreateExactTimeDependentSolution(IGrid1D grid, object physicalData, double dt);
    }
}