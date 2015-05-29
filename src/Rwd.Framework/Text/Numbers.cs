using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rwd.Framework.Text
{
    public class Numbers
    {

        public string ConvertToWords(decimal input, bool noCents)
        {
            return ConvertToWords(input.ToString(), noCents);
        }

        public static string ConvertToWords(string input, bool noCents)
        {
            long number = 0;
            long decimalPoint = 0;

            var nParts = input.Split(new string[] { "." }, StringSplitOptions.None);
            if (nParts.Length > 1)
            {
                number = long.Parse(nParts[0]);
                decimalPoint = long.Parse(nParts[1]);
                if (noCents)
                    return ConvertNumber(number);
                else
                    return ConvertNumber(number) + " And " + FindNumber(decimalPoint);
            }
            else
                return ConvertNumber(int.Parse(input));
        }

        public static string ConvertToDollars(decimal input)
        {
            return ConvertToDollars(input.ToString());
        }

        public static string ConvertToDollars(string input)
        {
            long number = 0;
            long decimalPoint = 0;

            var nParts = input.Split(new string[] { "." }, StringSplitOptions.None);
            if (nParts.Length > 1)
            {
                number = long.Parse(nParts[0]);
                decimalPoint = long.Parse(nParts[1]);
                return ConvertNumber(number) + "Dollars And " + FindNumber(decimalPoint) + " Cents";
            }
            else
                return ConvertNumber(int.Parse(input)) + " Dollars";
        }

        private static string ConvertNumber(long number)
        {

            var output = string.Empty;
            if (number < 1000)
                output = FindNumber(number);
            else
            {
                var nparts = new string[3];
                var n = string.Format("{0:C}", number).Replace("$", string.Empty).Replace(".00", string.Empty);

                nparts = n.Split(new string[] { "," }, StringSplitOptions.None);

                int i = number.ToString().Length;
                var p = 0;
                foreach (string s in nparts)
                {
                    var x = long.Parse(s);
                    p += 1;
                    if (p == nparts.Length)
                    {
                        if (x != 0)
                            output += " " + FindNumber(long.Parse(s));
                    }
                    else
                    {
                        if (x != 0)
                        {
                            if (output == null)
                                output += FindNumber(long.Parse(s)) + " " + FindSuffix(i, long.Parse(s));
                            else
                                output += " " + FindNumber(long.Parse(s)) + " " + FindSuffix(i, long.Parse(s));
                        }
                    }
                    i -= 3;
                }
            }
            return output;
        }

        private static string FindNumber(long number)
        {
            var words = string.Empty;
            var digits = new string[] { "Zero", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten" };
            var teens = new string[] { "", "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen" };

            if (number < 11)
                words = digits[number];
            else if (number < 20)
                words = teens[number - 10];
            else if (number == 20)
                words = "Twenty";
            else if (number < 30)
                words = "Twenty " + digits[number - 20];
            else if (number == 30)
                words = "Thirty";
            else if (number < 40)
                words = "Thirty " + digits[number - 30];
            else if (number == 40)
                words = "Fourty";
            else if (number < 50)
                words = "Fourty " + digits[number - 40];
            else if (number == 50)
                words = "Fifty";
            else if (number < 60)
                words = "Fifty " + digits[number - 50];
            else if (number == 60)
                words = "Sixty";
            else if (number < 70)
                words = "Sixty " + digits[number - 60];
            else if (number == 70)
                words = "Seventy";
            else if (number < 80)
                words = "Seventy " + digits[number - 70];
            else if (number == 80)
                words = "Eighty";
            else if (number < 90)
                words = "Eighty " + digits[number - 80];
            else if (number == 90)
                words = "Ninety";
            else if (number < 100)
                words = "Ninety " + digits[number - 90];
            else if (number < 1000)
            {
                words = number.ToString();
                words = words.Insert(1, ",");
                var wparts = words.Split(new string[] { "," }, StringSplitOptions.None);
                words = FindNumber(long.Parse(wparts[0])) + " " + "Hundred";
                var n = FindNumber(long.Parse(wparts[1]));
                if (long.Parse(wparts[1]) != 0)
                    words += " " + n;
            }

            return words;
        }

        private static string FindSuffix(long length, long l)
        {
            var word = string.Empty;

            if (l != 0)
            {
                if (length > 12)
                    word = "Trillion";
                else if (length > 9)
                    word = "Billion";
                else if (length > 6)
                    word = "Million";
                else if (length > 3)
                    word = "Thousand";
                else if (length > 2)
                    word = "Hundred";
                else
                    word = string.Empty;
            }
            else
                word = string.Empty;

            return word;
        }

        public class Range
        {
            public int Low { get; set; }
            public int High { get; set; }
        }


    }
}
