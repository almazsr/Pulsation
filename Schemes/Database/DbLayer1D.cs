using System.ComponentModel.DataAnnotations;
using Schemes.Helpers;
using Schemes.Interfaces;

namespace Schemes.Database
{
    public class DbLayer1D : ILayer1D
    {
        public DbLayer1D(double[] values)
        {
            Values = values;
            Data = Convert.ToBytes(values);
        }

        public DbLayer1D(byte[] data)
        {
            Data = data;
            Values = Convert.ToDoubles(data);
        }     

        public int TimeIndex { get; set; }

        public double Time { get; set; }

        public double this[int i]
        {
            get { return Values[i]; }
        }

        [Key]
        public int Id { get; set; }

        public int DbSolutionId { get; set; }

        internal byte[] Data { get; set; }

        internal double[] Values { get; set; }

        public virtual DbTimeDependentSolution1D DbSolution { get; set; }
    }
}