using System;

namespace Calculation.Interfaces
{
    public interface IScheme1D
    {
        void Solve(ISolution1D solution, IBoundaryCondition leftBoundaryCondition, IBoundaryCondition rightBoundaryCondition, IStopCondition stopCondition);

        event EventHandler Solved;
    }
}