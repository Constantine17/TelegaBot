using DataLayer.Specifications.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Specifications
{
    public class SelectAllSpecification<T> : ISpecification<T>
    {
        public bool IsSatisfiedBy(T candidate)
        {
            return true;
        }
    }
}
