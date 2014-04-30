using Pulsation.Models;
using Schemes.TimeDependent1D;

namespace Pulsation.Solvers
{
    public interface IPulsationLaminarSolver
    {
        PulsationLaminarPhysicalData PhysicalData { get; set; }

        TimeDependent1DSolution Solve(PulsationLaminarCalculationData calculationData);
    }
}