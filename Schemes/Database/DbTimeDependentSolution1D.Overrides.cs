using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Schemes.Interfaces;

namespace Schemes.Database
{
    public partial class DbTimeDependentSolution1D
    {
        public ILayer1D GetLayer(int timeIndex)
        {
            return DbLayers.ElementAt(timeIndex);
        }

        public double GetTime(int timeIndex)
        {
            return timeIndex*dt;
        }

        public void AddLayer(double[] values)
        {
            DbLayer1D layer = new DbLayer1D(values);
            layer.TimeIndex = CurrentTimeIndex + 1;
            layer.Time = GetTime(CurrentTimeIndex);
            DbLayers.Add(layer);
        }

        [NotMapped]
        public IGrid1D Grid
        {
            get { return DbGrid; }
        }

        [NotMapped]
        public ILayer1D CurrentLayer
        {
            get { return DbLayers.OrderByDescending(l => l.TimeIndex).FirstOrDefault(); }
        }

        [NotMapped]
        public int CurrentTimeIndex
        {
            get { return DbLayers.Count - 1; }
        }      

        [NotMapped]
        public double CurrentTime { get; private set; }
    }
}