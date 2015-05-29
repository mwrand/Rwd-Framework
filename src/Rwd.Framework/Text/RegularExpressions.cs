
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Rwd.Framework.Text
{
    public class RegularExpressions
    {

        #region Functions

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <param name="expression"></param>
        /// <returns></returns>
        public static bool IsInvalid(string input, string expression)
        {
            return RegularExpressions.IsInvalid(input, expression, new RegexOptions());
        }


        /// <summary>
        /// determines if their is a match in the input string for the given expression
        /// </summary>
        /// <param name="input"></param>
        /// <param name="expression"></param>
        /// <returns></returns>
        public static bool IsInvalid(string input, string expression, RegexOptions options)
        {
            return !RegularExpressions.IsValid(input, expression, options);
        }

        /// <summary>
        /// determines if their is a match in the input string for the given expression
        /// </summary>
        /// <param name="input"></param>
        /// <param name="expression"></param>
        /// <returns></returns>
        public static bool IsValid(string input, string expression)
        {
            return RegularExpressions.IsValid(input, expression, new RegexOptions());
        }

        /// <summary>
        /// determines if their is a match in the input string for the given expression
        /// </summary>
        /// <param name="input"></param>
        /// <param name="expression"></param>
        /// <returns></returns>
        public static bool IsValid(string input, string expression, RegexOptions options)
        {
            var valid = false;
            var re = new Regex(expression, options);
            if (re.IsMatch(input)) valid = true;
            return valid;
        }

        /// <summary>
        /// returns matching value from the input string, based on the given expression
        /// </summary>
        /// <param name="input"></param>
        /// <param name="expression"></param>
        /// <returns></returns>
        public static string GetValue(string input, string expression)
        {
            return RegularExpressions.GetValue(input, expression, new RegexOptions());
        }

        /// <summary>
        /// returns matching value from the input string, based on the given expression
        /// </summary>
        /// <param name="input"></param>
        /// <param name="expression"></param>
        /// <returns></returns>
        public static string GetValue(string input, string expression, RegexOptions options)
        {
            var re = new Regex(expression, options);
            return re.Match(input).Value.ToString();
        }

        /// <summary>
        ///  returns matching value from the input string, based on the given expressions.
        ///  first a match is made using expression1, then from that match value, the second
        ///  expression is run and the result value from this second match is returned.
        /// </summary>
        /// <param name="input"></param>
        /// <param name="expression"></param>
        /// <returns></returns>
        public static string GetValue(string input, string expression1, string expression2)
        {
            return RegularExpressions.GetValue(input, expression1, expression2, new RegexOptions());
        }

        /// <summary>
        ///  returns matching value from the input string, based on the given expressions.
        ///  first a match is made using expression1, then from that match value, the second
        ///  expression is run and the result value from this second match is returned.
        /// </summary>
        /// <param name="input"></param>
        /// <param name="expression"></param>
        /// <returns></returns>
        public static string GetValue(string input, string expression1, string expression2, RegexOptions options)
        {
            var re1 = new Regex(expression1, options);
            var value1 = re1.Match(input).Value.ToString();

            var re2 = new Regex(expression2, options);
            var value2 = re2.Match(value1).Value.ToString();

            return value2;
        }

        #endregion

        #region Properties

        // <summary> 
        // Matches major credit cards including: Visa (length 16, prefix 4); 
        // Mastercard (length 16, prefix 51-55); 
        // Diners Club/Carte Blanche (length 14, prefix 36, 38, or 300-305); 
        // Discover (length 16, prefix 6011); 
        // American Express (length 15, prefix 34 or 37). 
        // Saves the card type as a named group to facilitate further validation 
        // against a "card type" checkbox in a program. 
        // All 16 digit formats are grouped 4-4-4-4 with an optional hyphen or space 
        // between each group of 4 digits. 
        // The American Express format is grouped 4-6-5 with an optional hyphen or space 
        // between each group of digits. 
        // Formatting characters must be consistant, i.e. if two groups are separated by a hyphen, 
        // all groups must be separated by a hyphen for a match to occur. 
        // </summary> 
        public static string CreditCard()
        {
            return "^(?:(?<Visa>4\\d{3})|(?<Mastercard>5[1-5]\\d{2})|(?<Discover>6011)|(?<DinersClub>(?:3[68]\\d{2})|(?:30[0-5]\\d))|(?<AmericanExpress>3[47]\\d{2}))([ -]?)(?(DinersClub)(?:\\d{6}\\1\\d{4})|(?(AmericanExpress)(?:\\d{6}\\1\\d{5})|(?:\\d{4}\\1\\d{4}\\1\\d{4})))$";
        }

        // <summary> 
        // This matches a date in the format mm/dd/yy 
        // </summary> 
        // <example> 
        // Allows: 01/05/05, 12/30/99, 04/11/05 
        // Does not allow: 01/05/2000, 2/2/02 
        // </example> 
        public static string Date_MM_DD_YY()
        {
            return "^(1[0-2]|0[1-9])/(([1-2][0-9]|3[0-1]|0[1-9])/\\d\\d)$";
        }

        // <summary> 
        // This matches a date in the format mm/yy 
        // </summary> 
        // <example> 
        // Allows: 01/05, 11/05, 04/99 
        // Does not allow: 1/05, 13/05, 00/05 
        // </example> 
        public static string Date_MM_YY()
        {
            return "^((0[1-9])|(1[0-2]))\\/(\\d{2})$";
        }

        public static string LowerUpperAndNumber()
        {
            return @"^[a-zA-Z0-9]";
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static string Email()
        {
            return "^([0-9a-zA-Z]+[-._+&])*[0-9a-zA-Z]+@([-0-9a-zA-Z]+[.])+[a-zA-Z]{2,6}$";
        }

        /// <summary>
        /// Allows characters as mentioned in the above Email expression 
        /// </summary>
        /// <returns></returns>
        public static string EmailForUserName()
        {
            return "^([0-9a-zA-Z]+[-._+'&])*[0-9a-zA-Z]+@([-0-9a-zA-Z]+[.])+[a-zA-Z]{2,6}$";
        }

        // <summary> 
        // This matches an ip address in the format xxx-xxx-xxx-xxx 
        // each group of xxx must be less than or equal to 255 
        // </summary> 
        // <example> 
        // Allows: 123.123.123.123, 192.168.1.1 
        // </example> 
        public static string IPAddress()
        {
            return "^(?<First>2[0-4]\\d|25[0-5]|[01]?\\d\\d?)\\.(?<Second>2[0-4]\\d|25[0-5]|[01]?\\d\\d?)\\.(?<Third>2[0-4]\\d|25[0-5]|[01]?\\d\\d?)\\.(?<Fourth>2[0-4]\\d|25[0-5]|[01]?\\d\\d?)$";
        }

        // <summary> 
        // This matches any string with only alpha characters upper or lower case(A-Z) 
        // </summary> 
        // <example> 
        // Allows: abc, ABC, abCd, AbCd 
        // Does not allow: A C, abc!, (a,b) 
        // </example> 
        public static string Is_Alpha()
        {
            return "^[a-zA-Z]+$";
        }

        // <summary> 
        // Ensures the string only contains alpha-numeric characters, and 
        // not punctuation, spaces, line breaks, etc. 
        // </summary> 
        // <example> 
        // Allows: ab2c, 112ABC, ab23Cd 
        // Does not allow: A C, abc!, a.a 
        // </example> 
        public static string Is_AlphaNumeric()
        {
            return "^[a-zA-Z0-9]+$";
        }

        // <summary> 
        // This matches any string with only lower case alpha character(A-Z) 
        // </summary> 
        public static string Is_Lower()
        {
            return "^[a-z]+$";
        }

        // <summary> 
        // This matches only numbers(no decimals) 
        // </summary> 
        // <example> 
        // Allows: 0, 1, 123, 4232323, 1212322 
        // </example> 
        public static string Is_Number()
        {
            return "^[1-9|0]+$";
        }

        // <summary> 
        // This matches any string with only upper case alpha character(A-Z) 
        // </summary> 
        public static string Is_UpperCase()
        {
            return "^[A-Z]+$";
        }

        // <summary> 
        // Validates US Currency. Requires $ sign 
        // Allows for optional commas and decimal. 
        // No leading zeros. 
        // </summary> 
        // <example>Allows: $100,000 or $10000.00 or $10.00 or $.10 or $0 or $0.00 
        // Does not allow: $0.10 or 10.00 or 10,000</example> 
        public static string Is_USCurrency()
        {
            return "^\\$(([1-9]\\d*|([1-9]\\d{0,2}(\\,\\d{3})*))(\\.\\d{1,2})?|(\\.\\d{1,2}))$|^\\$[0](.00)?$";
        }

        // <summary> 
        // Matches x,x where x is a name, spaces are only allowed between comma and name 
        // </summary> 
        // <example> 
        // Allows: christophersen,eric; christophersen, eric 
        // Not allowed: christophersen ,eric; 
        // </example> 
        public static string NameComaName()
        {
            return @"[a-zA-Z\s\']+,\s?[a-zA-Z|\s]+";
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static string PascalCase()
        {
            return @"([A-Z]+[a-z]+)";
        }

        // <summary> 
        // Matches social security in the following format xxx-xx-xxxx 
        // where x is a number 
        // </summary> 
        // <example> 
        // Allows: 123-45-6789, 232-432-1212 
        // </example> 
        public static string SocialSecurity()
        {
            return @"\d{3}-\d{2}-\d{4}";
        }

        // <summary> 
        // This matches a url in the generic format 
        // scheme://authority/path?query#fragment 
        // </summary> 
        // <example> 
        // Allows: http://www.yahoo.com, https://www.yahoo.com, ftp://www.yahoo.com 
        // </example> 
        public string URL()
        {
            return "[http|https|ftp]+\\:\\/\\/[www\\.]?[\\w|\\-\\d]+[\\.\\w+]+";
        }

        // <summary> 
        // Permissive US Telephone Regex. Does not allow extensions. 
        // </summary> 
        // <example> 
        // Allows: 324-234-3433, (234)234-234, 234.234.234
        // </example> 
        public static string US_Telephone()
        {
            return "([\\(]?[0-9]{3}[\\(]?[\\.| |\\-]{0,1}|^[0-9]{3}[\\.|\\-| ]?)?[0-9]{3}(\\.|\\-| )?[0-9]{4}";
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static string US_ZipCode()
        {
            return @"\d{5}";
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static string US_ZipCodePlusFour()
        {
            return @"\d{5}[\-|\s]+\d{4}";
        }

        /// <summary> 
        /// this is a test 
        /// </summary> 
        /// <returns></returns> 
        /// <remarks></remarks> 
        public static string US_ZipCodePlusFourOptional()
        {
            return @"\d{5}((-|\s)?\d{4})?";
        }

        #endregion

    }
}
