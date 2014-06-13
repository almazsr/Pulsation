using System.Linq;
using Calculation.Classes.Data;
using Calculation.Helpers;
using Calculation.Interfaces;

namespace Calculation.Classes.Algorithms.TimeDependent.Continues
{
    public class ConvergencePeriodicContinue : IContinue
    {
        #region Constants
        public const double DefaultEpsilon = 1E-3; 
        #endregion

        public ConvergencePeriodicContinue(double epsilon = DefaultEpsilon)
        {
            this.Epsilon = epsilon;
        }

        public int IterationIndex { get; private set; }

        private bool _shouldStop;

        public double Epsilon { get; set; }

        public bool Continue(Bundle bundle)
        {
            var periodicBundle = (PeriodicSequenceBundle) bundle;
            if (_shouldStop)
            {
                return false;
            }
            if (periodicBundle.IsNewPeriod && !periodicBundle.IsFirstPeriod)
            {
                var previousLayers = periodicBundle.PreviousPeriodLayers;
                var currentLayers = periodicBundle.CurrentPeriodLayers;
                double difference =
                    previousLayers.Select((previousLayer, i) => previousLayer.Subtract(currentLayers[i]).NormInf()).Max();
                _shouldStop = difference < Epsilon;
            }
            return true;
        }
    }
}