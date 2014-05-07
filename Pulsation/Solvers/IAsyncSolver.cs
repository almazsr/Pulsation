using System;
using System.IO;

namespace Pulsation.Solvers
{
    public interface IAsyncSolver<TPhysicalData, TCalculationData, TSolution>
    {
        void BeginSolve(TextWriter textWriter);

        TPhysicalData PhysicalData { get; set; }

        TCalculationData CalculationData { get; set; }

        TSolution Solution { get; }

        event EventHandler Solved;
    }
}