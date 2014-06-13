using System;
using System.Diagnostics;
using Calculation.Classes.Data;
using Calculation.Interfaces;

namespace Calculation.Classes.Algorithms.TimeDependent.Continues
{
    public class CalculationTimeoutContinue : IContinue
    {
        public CalculationTimeoutContinue(TimeSpan timeout = default(TimeSpan))
        {
            this.Timeout = timeout == default(TimeSpan) ? DefaultTimeot : timeout;
            this._stopwatch = new Stopwatch();
        }

        public static readonly TimeSpan DefaultTimeot = new TimeSpan(0, 30, 0);

        public void Start()
        {
            _stopwatch.Start();
        }

        public TimeSpan Timeout { get; set; }
        private readonly Stopwatch _stopwatch;

        public bool Continue(Bundle group)
        {
            _stopwatch.Stop();
            bool result = _stopwatch.Elapsed < Timeout;
            _stopwatch.Start();
            return result;
        }
    }
}