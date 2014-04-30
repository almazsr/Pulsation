using System;
using System.IO;
using Schemes.Enums;
using Schemes.Interfaces;

namespace Schemes.Classes
{
    public class BoundaryCondition : IBoundaryCondition
    {
        public BoundaryCondition(Func<double, double> value, BoundaryConditionLocation location, BoundaryConditionType type)
        {
            Value = value;
            Location = location;
            Type = type;
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