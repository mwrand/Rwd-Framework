using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web;

namespace Rwd.Framework.Web
{
    public class Controls
    {


        /// <summary>
        /// 
        /// </summary>
        /// <param name="ddl"></param>
        /// <param name="dataSource"></param>
        /// <param name="dataTextField"></param>
        /// <param name="dataValueField"></param>
        public static void LoadDDL(ref DropDownList ddl, object dataSource, string dataTextField, string dataValueField)
        {

            Controls.LoadDDL(ref ddl, dataSource, dataTextField, dataValueField, string.Empty, string.Empty, true);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ddl"></param>
        /// <param name="dataSource"></param>
        /// <param name="dataTextField"></param>
        /// <param name="dataValueField"></param>
        public static void LoadDDL(ref DropDownList ddl, object dataSource, string dataTextField, string dataValueField, bool addStandardDefault)
        {

            Controls.LoadDDL(ref ddl, dataSource, dataTextField, dataValueField, string.Empty, string.Empty, addStandardDefault);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ddl"></param>
        /// <param name="dataSource"></param>
        /// <param name="dataTextField"></param>
        /// <param name="DataValueField"></param>
        /// <param name="defaultText"></param>
        /// <param name="defaultValue"></param>
        public static void LoadDDL(ref DropDownList ddl, object dataSource, string dataTextField, string dataValueField, string defaultText, string defaultValue)
        {

            Controls.LoadDDL(ref ddl, dataSource, dataTextField, dataValueField, defaultText, defaultValue, false);

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ddl"></param>
        /// <param name="dataSource"></param>
        /// <param name="dataTextField"></param>
        /// <param name="DataValueField"></param>
        /// <param name="defaultText"></param>
        /// <param name="defaultValue"></param>
        private static void LoadDDL(ref DropDownList ddl, object dataSource, string dataTextField, string dataValueField, string defaultText, string defaultValue, bool addStandardDefault)
        {
            ddl.Items.Clear();

            if (addStandardDefault)
                ddl.Items.Add(new ListItem("-- Select --", "0"));
            else
            {
                if (defaultText.Length > 0)
                    ddl.Items.Add(new ListItem("-- " + defaultText + " --", defaultValue));
            }

            ddl.AppendDataBoundItems = true;
            ddl.DataSource = dataSource;

            var isIntList = false;

            try
            {
                var test = (List<int>)dataSource;
                isIntList = true;
            }
            catch { }

            if (!isIntList)
            {
                ddl.DataTextField = dataTextField;
                ddl.DataValueField = dataValueField;
            }

            ddl.DataBind();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ddl"></param>
        public static void LoadDDLWithDefaultItem(ref DropDownList ddl)
        {
            ddl.Items.Insert(0, Controls.DefaultListItem);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="lb"></param>
        /// <param name="dataSource"></param>
        /// <param name="dataTextField"></param>
        /// <param name="dataValueField"></param>
        /// <param name="defaultText"></param>
        public static void LoadListBox(ref ListBox lb, object dataSource, string dataTextField)
        {
            Controls.LoadListBox(ref lb, dataSource, dataTextField, dataTextField);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="lb"></param>
        /// <param name="dataSource"></param>
        /// <param name="dataTextField"></param>
        /// <param name="dataValueField"></param>
        /// <param name="defaultText"></param>
        public static void LoadListBox(ref ListBox lb, object dataSource, string dataTextField, string dataValueField)
        {
            lb.Items.Clear();
            lb.DataSource = dataSource;
            lb.DataTextField = dataTextField;
            lb.DataValueField = dataValueField;
            lb.DataBind();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parent"></param>
        public static void ResetFormControlValues(Control parent)
        {
            foreach (Control c in parent.Controls)
            {
                if (c.Controls.Count > 0)
                    ResetFormControlValues(c);
                else
                {
                    switch (c.GetType().ToString())
                    {
                        case "System.Web.UI.WebControls.TextBox":
                            ((TextBox)c).Text = "";
                            break;
                        case "System.Web.UI.WebControls.CheckBox":
                            ((CheckBox)c).Checked = false;
                            break;
                        case "System.Web.UI.WebControls.DropDownList":
                            ((DropDownList)c).SelectedIndex = -1;
                            break;
                        case "System.Web.UI.WebControls.RadioButton":
                            ((RadioButton)c).Checked = false;
                            break;
                        case "System.Web.UI.WebControls.Label":
                            ((Label)c).Text = "";
                            break;
                    }
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="gridview"></param>
        public static void GridViewToExcel(GridView gridView)
        {
            GridViewToExcel(gridView, gridView.ID.Replace("GridView", string.Empty));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="gridview"></param>
        public static void GridViewToExcel(GridView gridView, string fileName)
        {
            HttpContext.Current.Response.Clear();
            HttpContext.Current.Response.AddHeader("content-disposition", string.Format("attachment;filename={0}.xls", fileName));
            HttpContext.Current.Response.Charset = "";

            // If you want the option to open the Excel file without saving then
            // comment out the line below
            HttpContext.Current.Response.Cache.SetCacheability(HttpCacheability.NoCache);
            HttpContext.Current.Response.ContentType = "application/vnd.xls";
            System.IO.StringWriter stringWriter = new System.IO.StringWriter();
            System.Web.UI.HtmlTextWriter htmlWriter = new HtmlTextWriter(stringWriter);
            gridView.RenderControl(htmlWriter);
            HttpContext.Current.Response.Write(stringWriter.ToString());
            HttpContext.Current.Response.End();
        }

        /// <summary>
        /// 
        /// </summary>
        private static ListItem defaultListItem = new ListItem("-- Select --", "0");
        public static ListItem DefaultListItem
        {
            get
            {
                return defaultListItem;
            }
            set
            {
                defaultListItem = value;
            }
        }

    }
}
