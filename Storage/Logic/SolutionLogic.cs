using System.Data.Entity;
using System.Linq;
using Storage.Database;

namespace Storage.Logic
{
    public static class SolutionLogic
    {
        public static DbSolution1D Get(int id)
        {
            using (DbSolutionContext db = new DbSolutionContext())
            {
                return db.GetSolution(id);
            }
        }

        public static DbSolution1D GetSolution(this DbSolutionContext db, int id)
        {
            return db.Solutions.FirstOrDefault(s => s.Id == id);
        }

        public static void SaveSolution(this DbSolutionContext db, DbSolution1D solution)
        {
            if (db.Entry(solution).State == EntityState.Detached)
            {
                db.Solutions.Attach(solution);
            }
        }

        public static void Save(DbSolution1D solution)
        {
            using (DbSolutionContext db = new DbSolutionContext())
            {
                db.SaveSolution(solution);
            }
        }

        public static void DeleteSolution(this DbSolutionContext db, int id)
        {
            var solution = db.GetSolution(id);
            db.Solutions.Remove(solution);
        }

        public static DbSolution1D Delete(int id)
        {
            using (DbSolutionContext db = new DbSolutionContext())
            {
                return db.GetSolution(id);
            }
        }
    }
}