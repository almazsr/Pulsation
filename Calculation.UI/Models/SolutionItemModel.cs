using System;
using Calculation.Enums;

namespace Calculation.UI.Models
{
    public class SolutionItemModel
    {
        public object Key { get; set; }

        public string Description { get; set; }

        public SolutionState State { get; set; }

        public bool IsExact { get; set; }

        public bool IsTimeDependent { get; set; }

        public string Grid { get; set; }

        public string PhysicalData { get; set; }

        public string SolverType { get; set; }

        public string TimeData { get; set; }

        public DateTime? Started { get; set; }

        public bool Selected { get; set; }
    }
}