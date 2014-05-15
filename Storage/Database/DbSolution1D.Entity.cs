using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Calculation.Enums;
using Calculation.Interfaces;

namespace Storage.Database
{
    public partial class DbSolution1D : ISolution1D
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime Started { get; set; }

        public SolutionState State { get; internal set; }

        public bool IsExact { get; set; }

        public string Method { get; set; }

        public bool IsTimeDependent { get; set; }

        public double TimeStep { get; set; }

        public int CurrentTimeIndex { get; set; }

        public int DbGridId { get; set; }
        public int DbPhysicalDataId { get; set; }
        public int DbCalculationDataId { get; set; }

        public virtual DbGrid1D DbGrid { get; set; }
        public virtual DbPhysicalData DbPhysicalData { get; set; }
        public virtual ICollection<DbLayer1D> DbLayers { get; set; }
    }
}