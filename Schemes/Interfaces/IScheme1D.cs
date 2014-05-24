using System;
using System.Collections.Generic;

namespace Calculation.Interfaces
{
    public interface IScheme1D
    {
        void Solve(ISolution1D solution, IBoundaryCondition leftBoundaryCondition, IBoundaryCondition rightBoundaryCondition, IEnumerable<IStopCondition> stopConditions);
        void SolveAsync(ISolution1D solution, IBoundaryCondition leftBoundaryCondition, IBoundaryCondition rightBoundaryCondition, IEnumerable<IStopCondition> stopConditions);

        event EventHandler Solved;
    }
}