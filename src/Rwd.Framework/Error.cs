using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace Rwd.Framework
{
    public class Error
    {

        public static string GetFormartedErrorMessage(Uri url, Exception exception)
        {

            var errorSB = new StringBuilder();

            if(url != null)
                errorSB.Append("<br>Error Page: " + url.ToString());

            errorSB.Append("<br>Source: " + exception.Source);
            errorSB.Append("<br>Message: " + exception.Message);
            errorSB.Append("<br>Stack trace: " + exception.StackTrace);

            if(exception.InnerException != null)
            {
                errorSB.Append(@"<div style=""padding:15px;"">");
                errorSB.Append("<br>Source: " + exception.InnerException.Source);
                errorSB.Append("<br>Message: " + exception.InnerException.Message);
                errorSB.Append("<br>Stack trace: " + exception.InnerException.StackTrace);
                errorSB.Append("</div>");
            }

            return errorSB.ToString();
        }
    }
}
