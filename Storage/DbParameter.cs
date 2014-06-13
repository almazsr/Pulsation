using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Calculation.Database
{
    public class DbParameter
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public double DoubleValue { get; set; }

        public string StringValue { get; set; }

        public int IntValue { get; set; }

        public ParameterType Type { get; set; }

        public virtual ICollection<DbGroup1D> DbSolutions { get; set; }
    }

    public enum ParameterType
    {
        Double = 0,
        String = 1,
        Int = 2
    }
}