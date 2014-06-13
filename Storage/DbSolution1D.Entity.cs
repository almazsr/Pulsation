using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Calculation.Enums;
using Calculation.Interfaces;

namespace Calculation.Database
{
    public partial class DbGroup : IGroup
    {
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Name of the solution.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Current time index.
        /// </summary>
        public int Nt { get; internal set; }

        [NotMapped]
        public object Key
        {
            get { return Id; }
        }

        /// <summary>
        /// Datetime, when solution has been started.
        /// </summary>
        public DateTime? StartedAt { get; set; }

        /// <summary>
        /// Solution state.
        /// </summary>
        public SolutionState State { get; internal set; }

        public virtual ICollection<DbLayer1D> DbLayers { get; set; }
        public virtual ICollection<DbParameter> DbParameters { get; set; }
    }
}