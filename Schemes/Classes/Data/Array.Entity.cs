using System.ComponentModel.DataAnnotations;

namespace Calculation.Classes.Data
{
    public partial class Array
    {
        public Array()
        {
            
        }

        [Key]
        public int Id { get; set; }

        public int Number { get; set; }

        public int BundleId { get; set; }

        public string Name { get; set; }

        public byte[] Data { get; set; }

        public virtual Bundle Bundle { get; set; }
    }
}