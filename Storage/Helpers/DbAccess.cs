using System.Collections.Generic;
using Calculation.Interfaces;

namespace Calculation.Database.Helpers
{
    public class DbAccess
    {
        public static ILayer1D GetLayer(ISolution1D solution, int nt)
        {
            using (DbSolutionContext db = new DbSolutionContext())
            {
                return db.GetLayer(solution, nt);
            }
        }

        public static void SaveLayers(IEnumerable<DbLayer1D> layers)
        {
            using (DbSolutionContext db = new DbSolutionContext())
            {
                db.Layers.AddRange(layers);
                db.SaveChanges();
            }
        }

        public static ILayer1D SaveLayer(DbLayer1D layer)
        {
            using (DbSolutionContext db = new DbSolutionContext())
            {
                return db.SaveLayer(layer);
            }
        }

        public static void SolutionNextTime(ISolution1D solution)
        {
            using (DbSolutionContext db = new DbSolutionContext())
            {
                db.SolutionNextTime(solution);
            }
        }
    }
}