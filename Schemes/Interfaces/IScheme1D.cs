using System;
using System.Collections.Generic;
using Schemes.Classes;

namespace Schemes.Interfaces
{
    public interface IScheme1D
    {
        IList<BoundaryCondition> BoundaryConditions { get; }

        void BeginSolve(IStopCondition stopCondition, IGrid1D grid, double[] initialValues, double dt);

        event EventHandler Solved;
    }
}