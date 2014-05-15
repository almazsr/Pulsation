using System.Data.Entity;
using Storage.Database;

namespace Storage.Logic
{
    public static class EntityLogic
    {
        private static void AttachEntity<T>(this DbSolutionContext db, T entity) where T : class
        {
            if (db.Entry(entity).State == EntityState.Detached)
            {
                db.Set<T>().Attach(entity);
            }
        }

        public static void InsertEntity<T>(this DbSolutionContext db, T entity) where T : class
        {
            db.AttachEntity(entity);
            db.Entry(entity).State = EntityState.Added;
        }

        public static void UpdateEntity<T>(this DbSolutionContext db, T entity) where T : class
        {
            db.AttachEntity(entity);
            db.Entry(entity).State = EntityState.Modified;
        }

        public static void DeleteEntity<T>(this DbSolutionContext db, T entity) where T : class
        {
            db.AttachEntity(entity);
            db.Entry(entity).State = EntityState.Deleted;
        }

        public static T Update<T>(T entity) where T : class 
        {
            using (DbSolutionContext db = new DbSolutionContext())
            {
                db.UpdateEntity(entity);
                return entity;
            }
        }

        public static T Insert<T>(T entity) where T : class
        {
            using (DbSolutionContext db = new DbSolutionContext())
            {
                db.InsertEntity(entity);
                return entity;
            }
        }

        public static void Delete<T>(T entity) where T : class
        {
            using (DbSolutionContext db = new DbSolutionContext())
            {
                db.DeleteEntity(entity);
            }
        }
    }
}