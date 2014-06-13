using Calculation.Classes.Data;

namespace Calculation.Classes.Algorithms.TimeDependent
{
    public class SequenceBundle : Bundle
    {
        public SequenceBundle()
        {
            
        }

        public SequenceBundle(string name, object data)
            : base(name, data, true)
        {
        } 

        public override Array AddArray(string name, int number, double[] values)
        {
            if (CurrentLayer != null)
            {
                PreviousLayer = CurrentLayer;
            }
            var array = base.AddArray(name, number, values);
            CurrentLayer = array;
            return array;
        }

        public Array CurrentLayer { get; private set; }
        public Array PreviousLayer { get; private set; }        
    }
}