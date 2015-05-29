using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rwd.Framework.Utility
{
    public static class Attributes
    {

       /// <summary>
        /// Gets all custom attributes for a property within the given type
       /// </summary>
       /// <param name="type"></param>
       /// <param name="propertyName"></param>
       /// <returns></returns>
        private static Dictionary<string, object> GetAllCustomAttributes(Type type, string propertyName)
        {
            return type.GetProperty(propertyName)
                                    .GetCustomAttributes(false)
                                    .ToDictionary(a => a.GetType().Name, a => a);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ex"></param>
        /// <returns></returns>
        private static Dictionary<string, object> GetACustomAttributesByName(Type type, string propertyName, string attributeName)
        {
            return type.GetProperty(propertyName)
                                     .GetCustomAttributes(false)
                                     .Where(p => p.GetType().ToString() == attributeName)
                                     .ToDictionary(a => a.GetType().Name, a => a);
        }


    }
}
