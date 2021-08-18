using DataLayer.Repository.Abstract;
using DataLayer.Specifications.Abstract;
using DataLayer.SQLite.Entities;
using SQLiteApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repository
{
    public class EventEntityRepository : IRepository<EventEntity>
    {
        private ApplicationContext db = new ApplicationContext();
        public void Create(EventEntity entity)
        {
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
