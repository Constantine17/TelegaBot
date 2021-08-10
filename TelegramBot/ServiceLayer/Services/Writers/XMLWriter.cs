using ServiceLayer.Services.Writers.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services.Writers
{
    public class XMLWriter<T> : IWriter<T>
    {
        public void Write(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
