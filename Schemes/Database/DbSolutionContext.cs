using System.Data.Entity;

namespace Schemes.Database
{
    public class DbSolutionContext : DbContext
    {
        public DbSet<DbTimeDependentSolution1D> Solutions { get; set; }
        public DbSet<DbLayer1D> Layers { get; set; }
        public DbSet<DbGrid1D> Grids { get; set; }
    }
}