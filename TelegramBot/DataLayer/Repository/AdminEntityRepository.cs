using DataLayer.Repository.Abstract;
using DataLayer.Specifications;
using DataLayer.Specifications.Abstract;
using DataLayer.SQLite.Entities;
using SQLiteApp;
using System.Linq;

namespace DataLayer.Repository
{
    public class AdminEntityRepository : IRepository<AdminEntity>
    {
        private ApplicationContext db = ApplicationContext.Instance;
        public void Create(AdminEntity entity)
        {
            var oldEntity = Get(new GetByIdSpecification(entity.ChatId));

            if (oldEntity != null)
            {
                Delete(new GetByIdSpecification(entity.ChatId));
                db.SaveChanges();
            }

            db.AdminEntities.Add(entity);
            db.SaveChanges();
        }

        public void Delete(ISpecification<AdminEntity> specification)
        {
            db.AdminEntities.RemoveRange(Get(specification));
            db.SaveChanges();
        }

        public IQueryable<AdminEntity> Get(ISpecification<AdminEntity> specification)
        {
            return db.AdminEntities.Where(specification.IsSatisfiedBy).AsQueryable();
        }
    }
}
