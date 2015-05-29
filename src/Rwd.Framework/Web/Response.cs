using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Rwd.Framework.Web
{
    public static class Response
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="downloadPath"></param>
        public static void WriteWordDocToWeb(string fileName, string downloadPath)
        {
            HttpContext.Current.Response.ClearContent();
            HttpContext.Current.Response.ClearHeaders();
            HttpContext.Current.Response.ContentType = "application/vnd.openxmlformats-officedocument.wordprocessingml.document";

            HttpContext.Current.Response.AddHeader("content-disposition", "attachment; filename=" + fileName);
            HttpContext.Current.Response.WriteFile(downloadPath + fileName);

            HttpContext.Current.Response.End();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="downloadPath"></param>
        public static void WriteExcelDocToWeb(string fileName, string downloadPath)
        {
            HttpContext.Current.Response.ClearContent();
            HttpContext.Current.Response.ClearHeaders();
            HttpContext.Current.Response.ContentType = "application/vnd.ms-excel";

            HttpContext.Current.Response.AddHeader("content-disposition", "attachment; filename=" + fileName);

            if (!downloadPath.EndsWith(@"\")) downloadPath += @"\";
            HttpContext.Current.Response.WriteFile(downloadPath + fileName);
            HttpContext.Current.Response.End();
        }


    }
}
