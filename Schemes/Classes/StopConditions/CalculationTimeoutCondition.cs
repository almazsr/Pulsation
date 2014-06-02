using System;
using Calculation.Exceptions;
using Calculation.Interfaces;

namespace Calculation.Classes.StopConditions
{
    public class CalculationTimeoutCondition : IStopCondition
    {
        public static readonly TimeSpan DefaultTimeout = new TimeSpan(0, 0, 10);

        public CalculationTimeoutCondition(TimeSpan timeout = default(TimeSpan))
        {
            this.Timeout = timeout == default(TimeSpan) ? DefaultTimeout : timeout;
        }

        public TimeSpan Timeout { get; set; }

        public bool IsFinish(ISolution1D solution)
        {
            if (solution.StartedAt == null)
            {
                throw new CalculationException("Solution not started.");
            }
            return DateTime.Now - solution.StartedAt.Value > Timeout;
        }
    }
}