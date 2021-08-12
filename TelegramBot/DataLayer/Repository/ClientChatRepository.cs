using DataLayer.Mappers;
using DataLayer.Repository.Abstract;
using DataLayer.Specifications;
using DataLayer.Specifications.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repository
{
    public class ClientChatRepository : IRepository<IClientChat>
    {
        private List<IClientChat> colection { get; set; } = new();

        public void Create(IClientChat entity)
        {
            Task.Factory.StartNew(()=> new ClientEntityRepository().Create(entity.Client.ToEntity()));

            if (colection.Contains(entity))
            {
                colection.Remove(entity);
            }
            colection.Add(entity);

        }

        public IQueryable<IClientChat> Get(ISpecification<IClientChat> specification)
        {
            return colection.Where(s => specification.IsSatisfiedBy(s)).AsQueryable();
        }

        public void Delete(ISpecification<IClientChat> specification)
        {
            colection.ToList().RemoveAll(s => specification.IsSatisfiedBy(s));
        }
    }
}
