using DataLayer.Repository.Abstract;
using DataLayer.Specifications.Abstract;
using DataLayer.Users.AdminModels.Abstract;
using System.Collections.Generic;
using System.Linq;

namespace DataLayer.Repository
{
    public class AdminChatRepository : IRepository<IAdminChat>
    {
        private List<IAdminChat> colection { get; set; } = new();

        public void Create(IAdminChat entity)
        {
            if (colection.Contains(entity))
            {
                colection.Remove(entity);
            }
            colection.Add(entity);
        }

        public IQueryable<IAdminChat> Get(ISpecification<IAdminChat> specification)
        {
            return colection.Where(specification.IsSatisfiedBy).AsQueryable();
        }

        public void Delete(ISpecification<IAdminChat> specification)
        {
            colection.ToList().RemoveAll(specification.IsSatisfiedBy);
        }

    }
}
