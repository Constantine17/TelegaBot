using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services.Registration.Abstract
{
    public interface IBehavior<in T>
    {
        void ExecuteBehavior(T parameter);
    }
}
