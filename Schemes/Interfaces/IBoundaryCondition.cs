using System;
using Schemes.Enums;

namespace Schemes.Interfaces
{
    public interface IBoundaryCondition
    {
        int Index { get; }

        Func<double, double> Value { get; set; }

        BoundaryConditionType Type { get; set; }

        BoundaryConditionLocation Location { get; set; }
    }
}