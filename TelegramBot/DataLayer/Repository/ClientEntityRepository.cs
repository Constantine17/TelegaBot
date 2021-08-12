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
    public class ClientEntityRepository : IRepository<ClientEntity>
    {
        private ApplicationContext db = new ApplicationContext();
        public void Create(ClientEntity entity)
        {
            db.ClientEntities.Add(entity);
        }

        public void Delete(ISpecification<ClientEntity> specification)
        {
            throw new NotImplementedException();
        }

        public IQueryable<ClientEntity> Get(ISpecification<ClientEntity> specification)
        {
            throw new NotImplementedException();
        }
    }
}
