using DataLayer.Specifications;
using DataLayer.Specifications.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repository.Abstract
{
    public interface IRepository<T>
    {
        void Create(T entity);

        IQueryable<T> Get(ISpecification<T> specification);

        void Delete(ISpecification<T> specification);
    }
}
