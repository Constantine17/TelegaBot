﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Loggers
{
    public class ConsolLogger : ILogger
    {
        public void SetMassage(string massage)
        {
            Console.WriteLine(massage);
        }

    }
}
