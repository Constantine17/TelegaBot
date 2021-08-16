using ServiceLayer.Extension;
using ServiceLayer.Services.Writers.Abstract;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services.Writers
{
    public class CSVWriter<T> : IWriter<T> where T: IQueryable
    {
        public void Write(T entity, string adress)
        {
            
            if (!File.Exists(adress))
            {
                var colonsName = new List<string> { "Им'я; Фамілія; Компанія; Посада; Чи були раніше?; Дата Регістрації" }.AsQueryable();
                colonsName.WriteToFile(adress);
            }
            entity.WriteToFile(adress);
        }
    }
}
