using DataLayer.Repository.Abstract;
using DataLayer.Specifications;
using DataLayer.Specifications.Abstract;
using DataLayer.SQLite.Entities;
using SQLiteApp;
using System.Linq;

namespace DataLayer.Repository
{
    public class EventEntityRepository : IRepository<EventEntity>
    {
        private ApplicationContext db = ApplicationContext.Instance;
        public void Create(EventEntity entity)
        {
            var oldEntity = Get(new ConditionalSpecification<EventEntity>(s => s.Id == entity.Id));

            if (oldEntity != null)
            {
                Delete(new ConditionalSpecification<EventEntity>(s => s.Id == entity.Id));
                db.SaveChanges();
            }

            db.EventEntities.Add(entity);
            db.SaveChanges();
        }

        public void Delete(ISpecification<EventEntity> specification)
        {
            db.EventEntities.RemoveRange(Get(specification));
            db.SaveChanges();
        }

        public IQueryable<EventEntity> Get(ISpecification<EventEntity> specification)
        {
            return db.EventEntities.Where(specification.IsSatisfiedBy).AsQueryable();
        }
    }
}
