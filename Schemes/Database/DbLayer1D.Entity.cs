using System.ComponentModel.DataAnnotations;

namespace Schemes.Database
{
    public partial class DbLayer1D
    {
        [Key]
        public int Id { get; set; }

        public int TimeIndex { get; set; }

        public double Time { get; set; }

        public int DbSolutionId { get; set; }

        internal byte[] Data { get; set; }

        public virtual DbTimeDependentSolution1D DbSolution { get; set; }
    }
}