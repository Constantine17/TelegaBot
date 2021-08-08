using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Massages
{
    public class Massage : IMassage
    {
        public string Text { get; }

        public Massage(string massage)
        {
            Text = massage;
        }
    }
}
