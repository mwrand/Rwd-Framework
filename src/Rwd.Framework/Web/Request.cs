using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Configuration;

namespace Rwd.Framework.Web
{
    public class Request
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static string ExtractBaseURLFromURL(Uri url, string application)
        {
            string docs = string.Empty;
            if (url.ToString().ToLower().Contains("/" + application.ToLower() + "/"))
                    docs = application + "/";

            return url.Scheme.ToString() + "://" + url.Authority + "/" + docs;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="thePage"></param>
        /// <returns></returns>
        public static Control GetControlThatCausedPostBack(Page thePage)
        {
            var myControl = new Control();
            var ctrlName = thePage.Request.Params.Get("__EventTarget");
            if(!string.IsNullOrEmpty(ctrlName))
                myControl = thePage.FindControl(ctrlName);
            else
            {
                // Since buttons are handled differently, loop through form
                // to find a control of type button.  Only the button that
                // c the postback will be contrain in the request object
                foreach(string item in thePage.Request.Form)
                {
                    var c = thePage.FindControl(item);
                    if(c.GetType() == Type.GetType("System.Web.UI.WebControls.Button"))
                    {
                        myControl = c;
                        break;
                    }
                }
            }
            return myControl;
        }

        /// <summary>
        /// Returns a list of db servers and tables from the connection strings in the web.config file of the calling website
        /// </summary>
        /// <returns></returns>
        public static string GetCurrentDbServers()
        {
            string dbServers = string.Empty;
            foreach(ConnectionStringSettings connectionString in ConfigurationManager.ConnectionStrings)
            {
                if(!connectionString.ToString().ToLower().Contains("sqlexpress"))
                {
                    var text = Regex.Match(connectionString.ToString(), @"Data\s\Source.+;Initial\sCatalog.+;", RegexOptions.IgnoreCase);
                    dbServers += text.Value + " ";
                }
            }
            return dbServers;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static string PhysicalAppDriveLetter()
        {
            if (HttpContext.Current.Request.PhysicalApplicationPath != null)
                return HttpContext.Current.Request.PhysicalApplicationPath.Substring(0, 1);
            else
                return string.Empty;
        }
    }
}
