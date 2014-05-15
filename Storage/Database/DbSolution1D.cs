using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Calculation.Interfaces;
using Storage.Logic;

namespace Storage.Database
{
    public partial class DbSolution1D
    {
        public ILayer1D GetLayer(int timeIndex)
        {
            return DbLayers.ElementAt(timeIndex);
        }

        public double GetTime(int timeIndex)
        {
            return timeIndex*TimeStep;
        }

        public void AddLayer(double[] values)
        {
            DbLayer1D layer = new DbLayer1D(values);
            layer.TimeIndex = CurrentTimeIndex;
            layer.Time = GetTime(CurrentTimeIndex);
            layer.DbSolutionId = Id;
            LayerLogic.Save(layer);
        }

        public void NextTime()
        {
            CurrentTimeIndex++;
        }

        [NotMapped]
        public IGrid1D Grid
        {
            get { return DbGrid; }
            set
            {                
                if (DbGrid == null) DbGrid = new DbGrid1D();
                DbGrid.Min = value.Min;
                DbGrid.Max = value.Max;
                DbGrid.N = value.N;
                DbGrid.h = value.h;
                DbGrid.Name = string.Format("[{0:0.##}, {1:0.##}]({2})", value.Min, value.Max, value.N);                
            }
        }

        [NotMapped]
        public ILayer1D CurrentLayer
        {
            get { return DbLayers.OrderByDescending(l => l.TimeIndex).FirstOrDefault(); }
        }

        [NotMapped]
        public double CurrentTime { get; private set; }
    }
}