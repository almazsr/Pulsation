using System.Collections.Generic;
using Schemes.Classes;
using Schemes.TimeDependent1D;

namespace Schemes.Interfaces
{
    public interface IScheme1D : IFinishCondition
    {
        TimeDependent1DSolution Solve(Grid1D grid, IList<BoundaryCondition> boundaryConditions, double[] initialLayer, double dt);
    }
}