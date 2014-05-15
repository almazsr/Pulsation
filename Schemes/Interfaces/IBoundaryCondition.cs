using System;
using Calculation.Enums;

namespace Calculation.Interfaces
{
    public interface IBoundaryCondition
    {
        int Index { get; }

        Func<double, double> Value { get; set; }

        BoundaryConditionType Type { get; set; }

        BoundaryConditionLocation Location { get; set; }
    }
}