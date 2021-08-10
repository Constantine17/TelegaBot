using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Specifications.Abstract
{
    public interface ISpecification<in T>
    {
        bool IsSatisfiedBy(T candidate);
    }
}
