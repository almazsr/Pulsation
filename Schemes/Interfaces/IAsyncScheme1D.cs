using System;
using System.Collections.Generic;
using Schemes.Classes;
using Schemes.TimeDependent1D;

namespace Schemes.Interfaces
{
    public interface IAsyncScheme1D : IFinishCondition
    {
        void BeginSolve(Grid1D grid, IList<BoundaryCondition> boundaryConditions, double[] initialLayer, double dt);

        TimeDependent1DSolution Solution { get; }

        event EventHandler Solved;        
    }
}