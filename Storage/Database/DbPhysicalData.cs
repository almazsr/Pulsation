using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Storage.Database
{
    public class DbPhysicalData
    {
        [Key, ForeignKey("DbSolution")]
        public int Id { get; set; }

        public byte[] Serialized { get; set; }

        public string Type { get; set; }

        [Required]
        public virtual DbSolution1D DbSolution { get; set; } 
    }
}