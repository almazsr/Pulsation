using System.ComponentModel.DataAnnotations.Schema;
using Calculation.Interfaces;
using Storage.Helpers;

namespace Storage.Database
{
    public partial class DbLayer1D : ILayer1D
    {
        internal DbLayer1D(double[] values)
        {
            this.Data = Convert.ToBytes(values);
        }

        internal DbLayer1D(double[] values, DbSolution1D solution)
            : this(values)
        {
            this.DbSolutionId = solution.Id;
            this.t = solution.tCurrent;
            this.nt = solution.Nt;
        }

        public double this[int i]
        {
            get { return Values[i]; }
        }

        private double[] _values;

        [NotMapped]
        internal double[] Values
        {
            get
            {
                return _values ?? (_values = Convert.ToDoubles(Data));
            }
        }
    }
}