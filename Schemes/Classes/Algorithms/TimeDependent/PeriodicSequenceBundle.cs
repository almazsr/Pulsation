using System.Collections.Generic;
using System.Linq;
using Calculation.Classes.Algorithms.TimeDependent.Extensions;
using Calculation.Classes.Data;

namespace Calculation.Classes.Algorithms.TimeDependent
{
    public class PeriodicSequenceBundle : SequenceBundle
    {
        public PeriodicSequenceBundle()
        {
            
        }

        public PeriodicSequenceBundle(string name, object data) : base(name, data)
        {
            _lastArrays = new List<Array>();
            PeriodN = this.PeriodN();
        }

        public override Array AddArray(string name, int number, double[] values)
        {
            var array = base.AddArray(name, number, values);
            var arrayCopy = new Array(array);
            _lastArrays.Add(arrayCopy);
            if (IsNewPeriod)
            {
                if (!IsFirstPeriod)
                {
                    PreviousPeriodLayers = CopyArrays(CurrentPeriodLayers);
                }
                CurrentPeriodLayers = CopyArrays(_lastArrays);
                _lastArrays.Clear();
            }
            return array;
        }

        private List<Array> CopyArrays(IEnumerable<Array> arrays)
        {
            return arrays.Select(l => new Array(l)).ToList();
        }

        public bool IsNewPeriod
        {
            get { return _count > 0 && _count%PeriodN == 0; }
        }

        public bool IsFirstPeriod
        {
            get { return _count / PeriodN == 1; }
        }

        private readonly List<Array> _lastArrays;

        public List<Array> CurrentPeriodLayers { get; private set; }
        public List<Array> PreviousPeriodLayers { get; private set; }

        public int PeriodN { get; private set; }
    }
}