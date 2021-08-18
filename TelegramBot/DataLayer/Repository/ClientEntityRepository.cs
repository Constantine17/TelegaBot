using DataLayer.Repository.Abstract;
using DataLayer.Specifications.Abstract;
using DataLayer.SQLite.Entities;
using SQLiteApp;
using System;
using System.Data.SQLite;
using System.IO;
using System.Linq;

namespace DataLayer.Repository
{
    public class ClientEntityRepository : IRepository<ClientEntity>
    {
        private ApplicationContext db = new ApplicationContext();
        public void Create(ClientEntity entity)
        {
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
