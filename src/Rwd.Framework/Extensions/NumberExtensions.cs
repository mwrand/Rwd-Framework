using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rwd.Framework.Extensions
{
    public static class NumberExtensions
    {

        public static int ToInt(this decimal number)
        {
            return (int)number;
        }

        public static int IntTryParse(this string text)
        {
            var newInt = 0;
            int.TryParse(text, out newInt);
            return newInt;
        }

        public static string ToCardinal(this int number)
        {
            string suffix = string.Empty;
            var numberStr = number.ToString();
            var lastDigit = int.Parse(numberStr.Substring(numberStr.Length - 1, 1));

            switch (lastDigit)
            {
                case 1:
                    suffix = "st";
                    break;

                case 2:
                    suffix = "nd";
                    break;

                case 3:
                    suffix = "rd";
                    break;

                default:
                    suffix = "th";
                    break;
            }

            if (numberStr.Length > 1)
            {
                var lastTwoDigits = int.Parse(numberStr.Substring(numberStr.Length - 2, 2));
                if (11 <= lastTwoDigits && lastTwoDigits <= 13) suffix = "th";
            }

            return number.ToString() + suffix;
        }

        public static string ToMoney(this decimal number)
        {
            return string.Format("{0:c}", number);
        }
    }
}
