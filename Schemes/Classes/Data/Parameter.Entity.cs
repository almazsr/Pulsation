using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Calculation.Enums;

namespace Calculation.Classes.Data
{
    public class Parameter
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public double DoubleValue { get; set; }

        public string StringValue { get; set; }

        public int IntValue { get; set; }

        public ParameterType Type { get; set; }

        public virtual ICollection<Bundle> Bundles { get; set; }
    }
}