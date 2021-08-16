using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Loggers
{
    public static class ConsolLogger
    {
        public static void SetMassage(string massage)
        {
            Console.WriteLine(massage);
        }


    }
}
