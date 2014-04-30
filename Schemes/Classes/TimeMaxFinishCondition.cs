using Schemes.Interfaces;
using Schemes.TimeDependent1D;

namespace Schemes.Classes
{
    public abstract class TimeMaxFinishCondition : IFinishCondition
    {
        public TimeMaxFinishCondition(double tMax)
        {
            TMax = tMax;
        }

        public virtual bool IsFinish(TimeDependent1DSolution solution)
        {
            return solution.tCurrent > TMax;
        }

        public double TMax { get; set; }
    }
}