using System.ComponentModel.DataAnnotations;

namespace Calculation.Database
{
    public partial class DbArray
    {
        public DbArray()
        {
            
        }

        [Key]
        public int Id { get; set; }

        public int Number { get; set; }

        public int DbSolutionId { get; set; }

        public int GroupId { get; set; }
        public string Name { get; set; }
        public byte[] Data { get; set; }

        public virtual DbGroup DbGroup { get; set; }
    }
}