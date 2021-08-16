using DataLayer.Specifications.Abstract;
using System.Linq;

namespace DataLayer.Repository.Abstract
{
    public interface IRepository<T>
    {
        void Create(T entity);

        IQueryable<T> Get(ISpecification<T> specification);

        void Delete(ISpecification<T> specification);
    }
}
