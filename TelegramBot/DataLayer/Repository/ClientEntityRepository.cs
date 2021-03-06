using DataLayer.Repository.Abstract;
using DataLayer.Specifications;
using DataLayer.Specifications.Abstract;
using DataLayer.SQLite.Entities;
using SQLiteApp;
using System.Linq;

namespace DataLayer.Repository
{
    public class ClientEntityRepository : IRepository<ClientEntity>
    {
        private ApplicationContext db = ApplicationContext.Instance;
        public void Create(ClientEntity entity)
        {
            var oldEntity = Get(new GetByIdSpecification(entity.ChatId));

            if (oldEntity != null)
            {
                Delete(new GetByIdSpecification(entity.ChatId));
                db.SaveChanges();
            }

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
