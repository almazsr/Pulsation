using System.Data.Entity;

namespace Storage.Database
{
    public class DbSolutionContext : DbContext
    {
        public DbSet<DbSolution1D> Solutions { get; set; }
        public DbSet<DbLayer1D> Layers { get; set; }
        public DbSet<DbGrid1D> Grids { get; set; }

        protected override void Dispose(bool disposing)
        {
            if (ChangeTracker.HasChanges())
            {
                SaveChanges();
            }
        }
    }
}