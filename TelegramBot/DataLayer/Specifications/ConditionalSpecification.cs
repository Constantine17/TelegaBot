using DataLayer.Specifications.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Specifications
{
    public class ConditionalSpecification<T> : ISpecification<T>
    {
        private readonly Func<T, bool> condition;

        public ConditionalSpecification(Func<T, bool> condition)
        {
            this.condition = condition;
        }

        public bool IsSatisfiedBy(T candidate)
        {
            return condition(candidate);
        }
    }
}
