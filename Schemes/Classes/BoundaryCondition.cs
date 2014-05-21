using System;
using System.IO;
using Calculation.Enums;
using Calculation.Interfaces;

namespace Calculation.Classes
{
    public class BoundaryCondition : IBoundaryCondition
    {
        public BoundaryCondition(BoundaryConditionLocation location, BoundaryConditionType type, Func<double, double> value)
        {
            Value = value;
            Location = location;
            Type = type;
        }

        public BoundaryCondition(BoundaryConditionLocation location, BoundaryConditionType type)
            : this(location, type, x => 0)
        {
        }

        public int Index
        {
            get
            { 
                switch (Location)
                {
                    case BoundaryConditionLocation.Left:
                        return 0;
                    case BoundaryConditionLocation.Right:
                        return 1;
                    default:
                        throw new InvalidDataException("Invalid location.");
                }
            }
        }

        public Func<double, double> Value { get; set; }

        public BoundaryConditionType Type { get; set; }
        public BoundaryConditionLocation Location { get; set; }
    }
}