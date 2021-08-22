using DataLayer.Repository.Abstract;
using DataLayer.Specifications;
using DataLayer.Specifications.Abstract;
using DataLayer.SQLite.Entities;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.DependencyInjection;
using SQLiteApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repository
{
    public class ClientWithEventsEntityRepository : IRepository<ClientWithEventsEntity>
    {
        private ApplicationContext db = ApplicationContext.Instance;
        public void Create(ClientWithEventsEntity entity)
        {
            var oldEntity = Get(new ConditionalSpecification<ClientWithEventsEntity>(s => s.EventId == entity.EventId));

            if (oldEntity != null)
            {
                Delete(new ConditionalSpecification<ClientWithEventsEntity>(s => s.EventId == entity.EventId));
                db.SaveChanges();
            }

            db.ClientWithEventsEntities.Add(entity);
            db.SaveChanges();
        }

        public void Delete(ISpecification<ClientWithEventsEntity> specification)
        {
            db.ClientWithEventsEntities.RemoveRange(Get(specification));
            db.SaveChanges();
        }

        public IQueryable<ClientWithEventsEntity> Get(ISpecification<ClientWithEventsEntity> specification)
        {
            return db.ClientWithEventsEntities.Where(specification.IsSatisfiedBy).AsQueryable();
        }
    }
}
