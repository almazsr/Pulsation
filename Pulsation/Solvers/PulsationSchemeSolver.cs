using Calculation.Classes.Algorithms.Solvers;
using Calculation.Classes.Algorithms.TimeDependent.Extensions;
using Calculation.Classes.Data;
using Pulsation.Models;

namespace Pulsation.Solvers
{
    public class PulsationSchemeSolver : PeriodicSchemeSolver<PulsationData>
    {
        public override string GetLayerName(Bundle bundle, int number)
        {
            double t = number * bundle.dt();
            return string.Format("U(r,{0:0.###})", t);
        }        
    }
}