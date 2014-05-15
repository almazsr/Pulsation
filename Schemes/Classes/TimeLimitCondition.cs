using Calculation.Interfaces;

namespace Calculation.Classes
{
    public class TimeLimitCondition : IStopCondition
    {
        public TimeLimitCondition(double tMax)
        {
            TMax = tMax;
        }

        public bool IsFinish(ISolution1D solution)
        {
            return solution.tCurrent > TMax;
        }

        public double TMax { get; set; }
    }
}