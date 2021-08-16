using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer
{
    public class Static
    {
        public Dictionary<List<string>, string> keyValues;

        public void GetTranslate(string test)
        {
            var t = keyValues.Keys.Where(s => s.Contains(test));
        }
    }
}
