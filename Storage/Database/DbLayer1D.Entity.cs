using System.ComponentModel.DataAnnotations;

namespace Storage.Database
{
    public partial class DbLayer1D
    {
        [Key]
        public int Id { get; set; }

        public int TimeIndex { get; set; }

        public double Time { get; set; }

        public int DbSolutionId { get; set; }

        internal byte[] Data { get; set; }

        public virtual DbSolution1D DbSolution { get; set; }
    }
}