using System.Data.Entity;

namespace Calculation.Database
{
    public class DbSolutionsInitializer : CreateDatabaseIfNotExists<DbSolutionContext>
    {
        protected override void Seed(DbSolutionContext context)
        {
            base.Seed(context);
        }
    }
}