using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Rwd.Framework.Web
{
    public class ResponseHelper
    {
        //public static void Redirect(string url, string target, string windowFeatures)
        //{
        //    HttpContext context = HttpContext.Current;
           
        //    if ((String.IsNullOrEmpty(target) ||
        //        target.Equals("_self", StringComparison.OrdinalIgnoreCase)) &&
        //        String.IsNullOrEmpty(windowFeatures))
        //    {

        //        context.Response.Redirect(url);
        //    }
        //    else
        //    {
        //        Page page = (Page)context.Handler;
        //        if (page == null)
        //        {
        //            throw new InvalidOperationException(
        //                "Cannot redirect to new window outside Page context.");
        //        }
        //        url = page.ResolveClientUrl(url);

        //        string script;
        //        if (!String.IsNullOrEmpty(windowFeatures))
        //        {
        //            script = @"window.open(""{0}"", ""{1}"", ""{2}"");";
        //        }
        //        else
        //        {
        //            script = @"window.open(""{0}"", ""{1}"");";
        //        }

        //        script = String.Format(script, url, target, windowFeatures);
        //      ScriptManager.RegisterStartupScript(page, page.GetType(), "Redirect", script, true);
        //    }
        //}
    }
}
