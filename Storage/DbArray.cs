using System.ComponentModel.DataAnnotations.Schema;
using Calculation.Database.Helpers;
using Calculation.Interfaces;

namespace Calculation.Database
{
    public partial class DbArray : IArray
    {        
        internal DbArray(double[] values)
        {
            this.Data = Convert.ToBytes(values);
        }

        internal DbArray(double[] values, DbGroup group)
            : this(values)
        {
            this.DbSolutionId = group.Id;
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