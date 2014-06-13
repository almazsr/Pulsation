using System.Collections.Generic;
using Calculation.Classes.Data;

namespace Calculation.Classes.Algorithms.TimeDependent.Extensions
{
    public static class TimeDependentBundleExtensions
    {
        public static double dt(this Bundle bundle)
        {
            return bundle.Parameter<double>("dt");
        }

        public static double Period(this Bundle bundle)
        {
            return bundle.Parameter<double>("Period");
        }

        public static bool IsTimeDependent(this Bundle bundle)
        {
            return bundle.dt() > 0;
        }

        public static bool IsPeriodic(this Bundle bundle)
        {
            return bundle.Period() > 0;
        }

        public static int PeriodN(this Bundle bundle)
        {
            return (int) (bundle.Period()/bundle.dt());
        }

        public static List<Array> GetLastPeriodLayers(this Bundle bundle, int step)
        {
            int periodN = bundle.PeriodN();
            int countInPeriod = periodN + 1;
            int count = bundle.GetCount();
            return bundle.GetSeparatedArrays(count - countInPeriod, countInPeriod, step);
        }
    }
}