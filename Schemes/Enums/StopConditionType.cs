using System;

namespace Calculation.Enums
{
    [Flags]
    public enum StopConditionType
    {
        CalculationTimeout = 1,
        TimeMax = 2,
        Convergence = 4
    }
}