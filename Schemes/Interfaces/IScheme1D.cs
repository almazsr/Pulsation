using System;
using Calculation.Classes;

namespace Calculation.Interfaces
{
    public interface IScheme1D
    {
        void Solve(ISolution1D solution, BoundaryCondition leftBoundaryCondition, BoundaryCondition rightBoundaryCondition, IStopCondition stopCondition);

        event EventHandler Solved;
    }
}