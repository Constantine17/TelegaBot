using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Dynamic.Core.Exceptions;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services
{
    public class SortService
    {
        public IQueryable TrySelectionProperties(IQueryable colection, string request, out bool isSuccessfully)
        {
            try
            {
                isSuccessfully = true;

                return colection.Select($"new({request})");
            }

            catch (ParseException)
            {
                isSuccessfully = false;
            }

            return colection;
        }
    }
}
