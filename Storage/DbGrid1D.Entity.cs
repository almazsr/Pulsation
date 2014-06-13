using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Calculation.Database
{
    public partial class DbGrid1D
    {
        public DbGrid1D()
        {
            
        }

        [Key]
        public int Id { get; set; }

        public double Min { get; set; }
        public double Max { get; set; }

        public double h { get; set; }

        public int N { get; set; }

        public string Name { get; set; }

        public virtual ICollection<DbGroup1D> DbSolutions { get; set; }
    }
}