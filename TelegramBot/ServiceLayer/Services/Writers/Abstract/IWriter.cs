using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services.Writers.Abstract
{
    public interface IWriter<in T>
    {
        public void Write(T entity, string adress);
    }
}
