using System;
using Calculation.Exceptions;
using Calculation.Interfaces;

namespace Calculation.Classes.StopConditions
{
    public class CalculationTimeoutCondition : IStopCondition
    {
        public CalculationTimeoutCondition(TimeSpan timeout)
        {
            this.Timeout = timeout;
        }

        public TimeSpan Timeout { get; set; }

        public bool IsFinish(ISolution1D solution)
        {
            if (solution.StartedAt == null)
            {
                throw new CalculationException("Solution not started.");
            }
            return DateTime.Now - solution.StartedAt.Value < Timeout;
        }
    }
}