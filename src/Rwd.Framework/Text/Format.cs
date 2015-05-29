using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Rwd.Framework.Text
{
    public class Format
    {

        /// <summary>
        /// Removes dollar signs and commas
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns></returns>
        public static string CleanMoney(string input)
        {
            if (input != null)
                return input.Replace("$", string.Empty).Replace(",", string.Empty).Trim();
            else
                return string.Empty;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string Remove(string input)
        {
            if (input != null)
                return input.Replace(".", string.Empty).Replace(" ", string.Empty).Replace("-", string.Empty).Replace("(", string.Empty).Replace(")", string.Empty);
            else
                return string.Empty;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public static string PhoneNumber(string number)
        {
            if (number != null)
            {
                number = number.Replace("-", string.Empty).Replace(" ", string.Empty);
                if (number.Length == 10)
                    return number.Insert(0, "(").Insert(4, ") ").Insert(9, "-");
                else if (number.Length == 7)
                    return number.Insert(3, "-");
                else
                    return number;
            }
            else
                return string.Empty;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public static string ZipCode(string number)
        {
            if (number != null)
            {
                number = number.Replace("-", string.Empty).Replace(" ", string.Empty);
                if (number.Length == 9)
                    return number.Insert(5, "-");
                else
                    return number;
            }
            else
                return string.Empty;
        }
    }
}
