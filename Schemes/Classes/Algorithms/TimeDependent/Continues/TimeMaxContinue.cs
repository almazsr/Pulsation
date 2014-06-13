using Calculation.Classes.Algorithms.TimeDependent.Extensions;
using Calculation.Classes.Algorithms.TimeDependent.Schemes;
using Calculation.Classes.Data;
using Calculation.Interfaces;

namespace Calculation.Classes.Algorithms.TimeDependent.Continues
{
    public class TimeMaxContinue : IContinue
    {
        public TimeMaxContinue(double timeMax)
        {
            this.TimeMax = timeMax;
        }

        public double TimeMax { get; set; }

        public bool Continue(Bundle group)
        {
            double t = group._count*group.dt();
            return t < TimeMax;
        }
    }
}