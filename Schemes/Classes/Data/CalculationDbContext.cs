using System.Collections.Generic;
using System.Configuration;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Data.SqlServerCe;
using System.Linq;

namespace Calculation.Classes.Data
{
    public class CalculationDbContext : DbContext
    {
        public CalculationDbContext()
            : this(CreateConnection(), true)
        {
            var objectContext = ((IObjectContextAdapter)this).ObjectContext;
            objectContext.ObjectMaterialized += OnObjectMaterialized;
        }

        internal CalculationDbContext(DbConnection connection, bool contextOwnsConnection)
            : base(connection, contextOwnsConnection)
        {
            Configuration.LazyLoadingEnabled = true;
        }

        internal CalculationDbContext(DbConnection connection)
            : base(connection, false)
        {
        }

        private void OnObjectMaterialized(object sender, ObjectMaterializedEventArgs e)
        {
            if (e.Entity is Bundle)
            {
                var bundle = (Bundle) e.Entity;
                bundle.Context = this;
            }
        }

        public DbSet<Bundle> Bundles { get; set; }
        public DbSet<Array> Arrays { get; set; }
        public DbSet<Parameter> Parameters { get; set; }

        internal static DbConnection CreateConnection(bool withOpen = false)
        {
            string connectionString =
                ConfigurationManager.ConnectionStrings["CalculationContextConnectionString"].ConnectionString;
            var connection = new SqlCeConnection(connectionString);
            if (withOpen)
            {                
                connection.Open();                
            }
            return connection;
        }

        public List<Bundle> GetGroups()
        {
            return Bundles.ToList();
        }

        public Bundle GetBundle(int id)
        {
            return Bundles.FirstOrDefault(b => b.Id == id);
        }

        public void DeleteBundle(int id)
        {
            var bundle = Bundles.FirstOrDefault(g => g.Id == id);
            Bundles.Remove(bundle);
        }
    }
}