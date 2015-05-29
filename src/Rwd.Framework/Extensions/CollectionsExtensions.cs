using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;

namespace Rwd.Framework.Extensions
{
    public static class CollectionExtensions
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static IEnumerable<int> ToInts(this IEnumerable<string> strings)
        {
            foreach (var item in strings)
            {
                int value = 0;
                int.TryParse(item, out value);
                yield return value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="U"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        public static string ToCommaSeparated<T, U>(this IEnumerable<T> source, Func<T, U> func)
        {
            return string.Join(", ", source.Select(s => func(s).ToString())).TrimEnd(',');
        }


    }
}
