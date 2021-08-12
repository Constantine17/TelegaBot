using DataLayer.SQLite.Entities;
using System.Data.Entity;

namespace SQLiteApp
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext() : base("Data Source= C:\\Users\\Mortem\\Desktop\\Bot\\TelegramBot\\DataLayer\\SQLite\\MBA_Bot.db")
        {
        }
        public DbSet<ClientEntity> ClientEntities { get; set; }
    }
}