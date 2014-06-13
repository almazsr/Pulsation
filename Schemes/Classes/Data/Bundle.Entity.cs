using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Calculation.Classes.Data
{
    public partial class Bundle
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public bool IsSequence { get; set; }

        public virtual ICollection<Array> Arrays { get; set; }
        public virtual ICollection<Parameter> Parameters { get; set; }
    }
}