using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Rwd.Framework.Text
{
    public class String
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string SplitStringByCapitals(string str)
        {
            string newstring = "";
            for (int i = 0; i < str.Length; i++)
            {
                if (char.IsUpper(str[i]) && i > 0)
                    newstring += " ";
                newstring += str[i].ToString();
            }
            return newstring;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string[] ToArrayByCapitals(string str)
        {
            string newstring = "";
            for (int i = 0; i < str.Length; i++)
            {
                if (char.IsUpper(str[i]) && i > 0)
                    newstring += " ";
                newstring += str[i].ToString();
            }
            return newstring.Split(new char[] { ' ' });
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string[] ToArray(string str, string delimiter)
        {
            if (str != null && str.Length > 0)
                return str.Split(new char[] { delimiter[0] });
            else
                return new string[0];

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string[] ToArray(string str, char[] delimiter)
        {
            if (str != null && str.Length > 0)
                return str.Split(delimiter);
            else
                return new string[0];
        }

        /// <summary>
        /// Replaces the insensitive.
        /// </summary>
        /// <param name="str">The string.</param>
        /// <param name="from">From.</param>
        /// <param name="to">To.</param>
        /// <returns></returns>
        public static string ReplaceInsensitive(string str, string from, string to)
        {
            str = Regex.Replace(str, from, to, RegexOptions.IgnoreCase);
            return str;
        }


    }
}
