using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Massages
{
    public class UnknownСommandMassage : IMassage
    {
        public string Text => "Невідома команда";
    }
}
