using DataLayer.ClientModels;
using DataLayer.Repository.Abstract;
using DataLayer.Specifications.Abstract;
using System.Collections.Generic;
using System.Linq;

namespace DataLayer.Repository
{
    public class ClientChatRepository : IRepository<IClientChat>
    {
        private List<IClientChat> colection { get; set; } = new();

        public void Create(IClientChat entity)
        {
            if (colection.Contains(entity))
            {
                colection.Remove(entity);
            }
            colection.Add(entity);
        }

        public IQueryable<IClientChat> Get(ISpecification<IClientChat> specification)
        {
            return colection.Where(specification.IsSatisfiedBy).AsQueryable();
        }

        public void Delete(ISpecification<IClientChat> specification)
        {
            colection.ToList().RemoveAll(specification.IsSatisfiedBy);
        }
    }
}
