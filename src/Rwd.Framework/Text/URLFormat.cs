using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rwd.Framework.Text
{
    public static class URLFormat
    {

        public static string UrlEncode(string text)
        {
            return text.Replace(" ", "-");
        }

        public static string DecodeUrl(string text)
        {
            return text.Replace("-", " ");
        }

    }
}
