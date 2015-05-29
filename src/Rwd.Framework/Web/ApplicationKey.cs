using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Configuration;
using System.Collections;
using ad = Rwd.Framework.Windows.ActiveDirectory;

namespace Rwd.Framework.Web
{
    public static class ApplicationKey
    {

        /// <summary>
        /// 
        /// </summary>
        public static List<ad.Users> AdUsers
        {
            get
            {
                if (HttpContext.Current.Cache["AdUsers"] == null)
                    HttpContext.Current.Cache.Insert("AdUsers", Rwd.Framework.Windows.ActiveDirectory.GetUsers());
                return (List<ad.Users>)HttpContext.Current.Cache["AdUsers"];
            }
            set
            {
                HttpContext.Current.Cache.Insert("AdUsers", value);
            }
        }


        /// <summary>
        /// 
        /// </summary>
        public static string ApplicationName
        {
            get
            {
                if (HttpContext.Current.Cache["ApplicationName"] == null)
                    HttpContext.Current.Cache.Insert("ApplicationName", System.Reflection.Assembly.GetCallingAssembly().GetName().Name);
                return HttpContext.Current.Cache["ApplicationName"].ToString();
            }
            set
            {
                HttpContext.Current.Cache.Insert("ApplicationName", value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public static string ErrorInfo
        {
            get
            {
                if (HttpContext.Current.Cache["ErrorInfo"] == null)
                    HttpContext.Current.Cache.Insert("ErrorInfo", string.Empty);
                return HttpContext.Current.Cache["ErrorInfo"].ToString();
            }
            set
            {
                HttpContext.Current.Cache.Insert("ErrorInfo", value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public static bool InDevelopment
        {
            get
            {
                if (HttpContext.Current.Cache["InDevelopment"] == null)
                    HttpContext.Current.Cache.Insert("InDevelopment", bool.Parse(ConfigurationManager.AppSettings["InDevelopment"].ToString()));
                return (bool)HttpContext.Current.Cache["InDevelopment"];
            }
            set
            {
                HttpContext.Current.Cache.Insert("InDevelopment", value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public static System.Exception LastError
        {
            get
            {
                if (HttpContext.Current.Cache["LastError"] == null)
                    return null;
                else
                    return (System.Exception)HttpContext.Current.Cache["LastError"];
            }
            set
            {
                HttpContext.Current.Cache.Insert("LastError", value);
            }
        }

    }
}
