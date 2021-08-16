using DataLayer.Repository.Abstract;
using DataLayer.Specifications.Abstract;
using DataLayer.SQLite.Entities;
using SQLiteApp;
using System.Data.SQLite;
using System.Linq;

namespace DataLayer.Repository
{
    public class ClientEntityRepository : IRepository<ClientEntity>
    {
        private ApplicationContext db = new ApplicationContext(new SQLiteConnection() { ConnectionString = @"Data Source =C:\Users\Mortem\Desktop\Bot\TelegramBot\\DataLayer\\SQLite\\MBA_Bot.db" });
        public void Create(ClientEntity entity)
        {
            db.Database.ExecuteSqlCommand("CREATE TABLE IF NOT EXISTS 'ClientEntities' ('Id' INTEGER NOT NULL PRIMARY KEY, 'ChatId','FirstName' TEXT, 'LastName' TEXT,  'Company' TEXT, 'Position' TEXT, 'MemberBefore' TEXT, 'Role' TEXT, 'RigistrationDate' TEXT)");

            db.ClientEntities.Add(entity);

            db.SaveChanges();
        }

        public void Delete(ISpecification<ClientEntity> specification)
        {
            db.ClientEntities.RemoveRange(Get(specification));
            db.SaveChanges();
        }

        public IQueryable<ClientEntity> Get(ISpecification<ClientEntity> specification)
        {
            return db.ClientEntities.Where(specification.IsSatisfiedBy).AsQueryable();
        }
    }
}
