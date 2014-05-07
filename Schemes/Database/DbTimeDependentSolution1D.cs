using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Schemes.Interfaces;

namespace Schemes.Database
{
    public partial class DbTimeDependentSolution1D : ITimeDependentSolution1D, ITimeDependentSolution1DInternal
    {
        [Key]
        public int Id { get; set; }

        public int DbGridId { get; set; }

        public bool IsExact { get; set; }

        public string SchemeType { get; set; }

        public double dt { get; set; }

        public string Name { get; set; }

        public virtual DbGrid1D DbGrid { get; set; }

        public virtual ICollection<DbLayer1D> DbLayers { get; set; }
    }
}