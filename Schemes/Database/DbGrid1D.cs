using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Schemes.Interfaces;

namespace Schemes.Database
{
    public class DbGrid1D : IGrid1D
    {
        [Key]
        public int Id { get; set; }

        public double Min { get; set; }
        public double Max { get; set; }

        public double h { get; set; }

        public int N { get; set; }

        public string Name { get; set; }

        [NotMapped]
        public double this[int i]
        {
            get { return i*h; }
        }

        public virtual ICollection<DbTimeDependentSolution1D> DbSolutions { get; set; }
    }
}