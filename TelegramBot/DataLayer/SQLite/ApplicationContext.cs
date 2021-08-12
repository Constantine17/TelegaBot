using DataLayer.SQLite;
using DataLayer.SQLite.Entities;
using System.Data.Common;
using System.Data.Entity;

namespace SQLiteApp
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbConnection connection) : base(connection, true)
        {
            DbConfiguration.SetConfiguration(new SQLiteConfiguration());
        }
        public DbSet<ClientEntity> ClientEntities { get; set; }
    }
}