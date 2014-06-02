using System.Linq;
using Calculation.Helpers;
using Calculation.Interfaces;

namespace Calculation.Classes.StopConditions
{
    public class ConvergencePeriodicCondition : IStopCondition
    {
        #region Constants
        public const double DefaultEpsilon = 1E-3; 
        #endregion

        public ConvergencePeriodicCondition(double epsilon = DefaultEpsilon)
        {
            this.Epsilon = epsilon;
        }

        public int IterationIndex { get; private set; }

        public double Epsilon { get; set; }

        public bool IsFinish(ISolution1D solution)
        {
            int k = IterationIndex / solution.PeriodNt;
            if (k > 1 && IterationIndex % solution.PeriodNt == 0)
            {
                IterationIndex++;
                var previousLayers = solution.GetLayers(solution.Nt - 2 * solution.PeriodNt, solution.PeriodNt);
                var currentLayers = solution.GetLayers(solution.Nt - solution.PeriodNt, solution.PeriodNt);
                double difference =
                    previousLayers.Select((previousLayer, i) => previousLayer.Subtract(currentLayers[i]).NormInf()).Max();
                return difference < Epsilon;
            }
            else
            {
                IterationIndex++; 
                return false;
            }
        }
    }
}