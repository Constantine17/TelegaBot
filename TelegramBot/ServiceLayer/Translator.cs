using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer
{
    public static class Translator
    {
        private static Dictionary<List<string>, string> keyValues = new()
        {
            { new List<string> { "имя", "имени", "ім'я", "ім'ю" }, "FirstName" },
            { new List<string> { "фамилия", "фамілія", "фамилию", "фамілію" }, "LastName" },
            { new List<string> { "компания", "компанія", "компанию", "компанію" }, "Company" },
            { new List<string> { "был", "посещал", "раньше", "був", "відвідував", "раніше" }, "MemberBefore" },
            { new List<string> { "дата", "дату", "регистрации", "регистрация", "регистрації", "регистрація" }, "RigistrationDate" },
        };


        public static void GetTranslate(string test)
        {
            var t = keyValues.Keys.Where(s => s.Contains(test));
        }
    }
}
