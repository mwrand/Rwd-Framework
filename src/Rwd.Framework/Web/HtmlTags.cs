using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rwd.Framework.Web
{
    public static class HtmlTags
    {

        #region Functions

        /// <summary>
        /// Returns innerText within bold tags
        /// </summary>
        /// <param name="tagName"></param>
        /// <param name="innerText"></param>
        /// <returns></returns>
        public static string B(string innerText)
        {
            return Generic("b", innerText);
        }

        /// <summary>
        /// Returns innerText within div tags
        /// </summary>
        /// <param name="tagName"></param>
        /// <param name="innerText"></param>
        /// <returns></returns>
        public static string Div(string innerText)
        {
            if (string.IsNullOrEmpty(innerText)) innerText = "&nbsp;";
            return Generic("div", innerText);
        }

        /// <summary>
        /// Returns innerText within span tags
        /// </summary>
        /// <param name="tagName"></param>
        /// <param name="innerText"></param>
        /// <returns></returns>
        public static string Div(string className, string innerText)
        {
            if (string.IsNullOrEmpty(innerText)) innerText = "&nbsp;";
            return Generic("div", className, innerText);
        }

        /// <summary>
        /// Returns innerText within span tags
        /// </summary>
        /// <param name="innerText"></param>
        /// <returns></returns>
        public static string Span(string innerText)
        {
            return Generic("span", innerText);
        }

        /// <summary>
        /// Returns innerText within bold tags
        /// </summary>
        /// <param name="className"></param>
        /// <param name="innerText"></param>
        /// <returns></returns>
        public static string Span(string className, string innerText)
        {
            return Generic("span", className, innerText);
        }

        /// <summary>
        /// Returns innerText within appropriate html tags
        /// </summary>
        /// <param name="tagName"></param>
        /// <param name="innerText"></param>
        /// <returns></returns>
        public static string Generic(string tagName, string innerText)
        {
            if (string.IsNullOrEmpty(tagName)) return string.Empty;
            return "<" + tagName + ">" + innerText + "</" + tagName + ">";
        }

        /// <summary>
        /// Returns innerText within appropriate html tags
        /// </summary>
        /// <param name="tagName"></param>
        /// <param name="className"></param>
        /// <param name="innerText"></param>
        /// <returns></returns>
        public static string Generic(string tagName, string className, string innerText)
        {
            if (string.IsNullOrEmpty(tagName))
                return string.Empty;
            if (string.IsNullOrEmpty(className))
                return Generic(tagName, innerText);
            else
                return "<" + tagName + @" class=""" + className + @""">" + innerText + "</" + tagName + ">";
        }

        #region ListItems

        /// <summary>
        /// Returns the string : <li class="[cssClass]">
        /// </summary>
        /// <returns></returns>
        public static string ListItemOpenTag(string cssClass)
        {
            return HtmlTags.ListItemOpenTag(cssClass, string.Empty);
        }

        /// <summary>
        /// Returns the string : <li id="[id]" class="[cssClass]">
        /// </summary>
        /// <returns></returns>
        public static string ListItemOpenTag(string cssClass, string id)
        {
            var sb = new StringBuilder();
            sb.Append("<li");

            if (id.Length > 0)
                sb.Append(" id=" + id + @"""");

            if (cssClass.Length > 0)
                sb.Append(" class=" + cssClass + @"""");

            sb.Append(">");

            return sb.ToString();
        }

        #endregion

        #endregion

        #region Properties

        /// <summary>
        /// 
        /// </summary>
        public static string br
        {
            get { return "<br />"; }
        }

        /// <summary>
        /// 
        /// </summary>
        public static string Br
        {
            get { return br; }
        }

        /// <summary>
        /// 
        /// </summary>
        public static string BR
        {
            get { return br; }
        }

        /// <summary>
        ///
        /// </summary>
        public static string LIOpenTag
        {
            get { return HtmlTags.ListItemOpenTag(string.Empty, string.Empty); }
        }

        /// <summary>
        /// 
        /// </summary>
        public static string LICloseTag
        {
            get { return "</li>"; }
        }

        #endregion

    }
}
