using System.ComponentModel.DataAnnotations;

namespace Calculation.Database
{
    public partial class DbLayer1D
    {
        public DbLayer1D()
        {
            
        }

        [Key]
        public int Id { get; set; }

        public int nt { get; set; }

        public double t { get; set; }

        public int DbSolutionId { get; set; }

        internal byte[] Data { get; set; }

        public virtual DbSolution1D DbSolution { get; set; }
    }
}