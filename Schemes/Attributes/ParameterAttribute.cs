using System;

namespace Calculation.Classes.Data
{
    public class ParameterAttribute : Attribute
    {
        public ParameterAttribute(string description)
        {
            this.Description = description;
        }

        public string Description { get; set; }
    }
}