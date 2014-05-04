using Schemes.Interfaces;
using Schemes.TimeDependent1D;

namespace Schemes.Classes
{
    public class TimeLimitCondition : IStopCondition
    {
        public TimeLimitCondition(double tMax)
        {
            TMax = tMax;
        }

        public bool IsFinish(TimeDependent1DSolution solution)
        {
            return solution.tCurrent > TMax;
        }

        public double TMax { get; set; }
    }
}