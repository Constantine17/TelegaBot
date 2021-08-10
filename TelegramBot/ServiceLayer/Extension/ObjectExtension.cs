using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Extension
{
    public static class ObjectExtension
    {
        /// <summary>
        /// Checks if content is the default
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static bool IsDefault(this object obj)
        {
            if (obj == null)
                return true;

            if (obj.GetType().IsValueType)
                return (obj == null) ? true : obj.GetType().Assembly.CreateInstance(obj.GetType().FullName).Equals(obj);

            if (obj is string str)
            {
                if (str == string.Empty || str == null)
                    return true;
            }

            return false;
        }
    }
}
