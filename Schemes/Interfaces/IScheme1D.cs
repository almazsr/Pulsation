using System.Collections.Generic;
using Schemes.Classes;
using Schemes.TimeDependent1D;

namespace Schemes.Interfaces
{
    public interface IScheme1D
    {
        IList<BoundaryCondition> BoundaryConditions { get; }

        TimeDependent1DSolution Solve(IStopCondition stopCondition, Grid1D grid, double[] initialLayer, double dt);
    }
}