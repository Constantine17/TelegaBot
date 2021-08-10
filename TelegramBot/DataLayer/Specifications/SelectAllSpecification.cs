using DataLayer.Specifications.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Specifications
{
    public class SelectAllSpecification : ISpecification<IClientChat>
    {
        public bool IsSatisfiedBy(IClientChat candidate)
        {
            return true;
        }
    }
}
