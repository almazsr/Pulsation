using Calculation.Interfaces;

namespace Calculation.Classes.StopConditions
{
    public class TimeMaxCondition : IStopCondition
    {
        public TimeMaxCondition(double tMax)
        {
            TMax = tMax;
        }

        public virtual bool IsFinish(ISolution1D solution)
        {
            return solution.tCurrent > TMax;
        }

        public double TMax { get; set; }
    }
}