using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.BotBehavior.Abstract
{
    public interface IBehavior<in T>
    {
        IBehavior<T> NextBehavior { get;}
        void ExecuteBehavior(T parameter);
    }
}
