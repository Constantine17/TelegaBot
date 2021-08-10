using DataLayer.Specifications.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Specifications
{
    public class ConditionalSpecification : ISpecification<IClientChat>
    {
        private readonly Func<IClientChat, bool> condition;

        public ConditionalSpecification(Func<IClientChat, bool> condition)
        {
            this.condition = condition;
        }

        public bool IsSatisfiedBy(IClientChat candidate)
        {
            return condition(candidate);
        }
    }
}
