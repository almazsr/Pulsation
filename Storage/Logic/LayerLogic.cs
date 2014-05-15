using System.Linq;
using Storage.Database;
using Storage.Helpers;

namespace Storage.Logic
{
    public static class LayerLogic
    {
        public static void AddLayer(this DbSolutionContext db, DbLayer1D layer)
        {
            layer.Data = Convert.ToBytes(layer.Values);
            db.InsertEntity(layer);
        }

        public static void Add(DbLayer1D layer)
        {
            using (DbSolutionContext db = new DbSolutionContext())
            {
                db.AddLayer(layer);               
            }
        }

        public static void RemoveLayer(this DbSolutionContext db, DbLayer1D layer)
        {
            db.DeleteEntity(layer);
        }

        public static void Remove(DbLayer1D layer)
        {
            using (DbSolutionContext db = new DbSolutionContext())
            {
                db.RemoveLayer(layer);
            }
        }

        public static DbLayer1D GetLayerByIndexForSolution(this DbSolutionContext db, int solutionId, int timeIndex)
        {
            var layer = db.Layers.FirstOrDefault(l => l.DbSolutionId == solutionId && l.TimeIndex == timeIndex);
            if (layer != null)
            {
                layer.Values = Convert.ToDoubles(layer.Data);
            }
            return layer;
        }
    }
}