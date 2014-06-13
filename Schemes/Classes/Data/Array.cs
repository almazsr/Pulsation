using System.ComponentModel.DataAnnotations.Schema;
using Calculation.Helpers;

namespace Calculation.Classes.Data
{
    public partial class Array
    {  
        internal Array(Array copy) : this(copy.Name, copy.Number, copy.Values, copy.BundleId)
        {
            
        }

        internal Array(string name, int number, double[] values, int bundleId)
        {
            this.Name = name;
            this.Number = number;
            this.Data = Convert.ToBytes(values);
            this.BundleId = bundleId;
        }

        public double this[int i]
        {
            get { return Values[i]; }
        }

        private double[] _values;

        [NotMapped]
        public double[] Values
        {
            get
            {
                return _values ?? (_values = Convert.ToDoubles(Data));
            }
            set
            {
                if (value != null)
                {
                    Data = Convert.ToBytes(value);
                }
            }
        }
    }
}