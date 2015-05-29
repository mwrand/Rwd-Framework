using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rwd.Framework.Windows.Office.Excel
{
    public class Helper
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="columnNumber"></param>
        /// <returns></returns>
        public static string GetExcelColumnName(int columnNumber)
        {
            int dividend = columnNumber;
            string columnName = String.Empty;
            int modulo;

            while (dividend > 0)
            {
                modulo = (dividend - 1) % 26;
                columnName = Convert.ToChar(65 + modulo).ToString() + columnName;
                dividend = (int)((dividend - modulo) / 26);
            }

            return columnName;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static int TranslateColumnNameToIndex(string name)
        {
            int position = 0;

            var chars = name.ToUpperInvariant().ToCharArray().Reverse().ToArray();
            for (var index = 0; index < chars.Length; index++)
            {
                var c = chars[index] - 64;
                position += index == 0 ? c : (c * (int)Math.Pow(26, index));
            }

            return position;
        }

    }
}
