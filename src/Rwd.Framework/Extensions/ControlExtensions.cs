using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;

namespace Rwd.Framework.Extensions
{
    public static class ControlExtensions
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="gridView"></param>
        /// <param name="dataSource"></param>
        public static void DataBind(this GridView gridView, object dataSource)
        {
            gridView.DataSource = dataSource;
            gridView.DataBind();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ddl"></param>
        /// <param name="dataSource"></param>
        /// <param name="dataTextField"></param>
        /// <param name="DataValueField"></param>
        public static void LoadDDL(this DropDownList ddl, object dataSource)
        {
            Rwd.Framework.Web.Controls.LoadDDL(ref ddl, dataSource, string.Empty, string.Empty);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ddl"></param>
        /// <param name="dataSource"></param>
        /// <param name="dataTextField"></param>
        /// <param name="DataValueField"></param>
        public static void LoadDDL(this DropDownList ddl, object dataSource, string dataTextField, string DataValueField)
        {
            Rwd.Framework.Web.Controls.LoadDDL(ref ddl, dataSource, dataTextField, DataValueField);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ddl"></param>
        /// <param name="dataSource"></param>
        /// <param name="dataTextField"></param>
        /// <param name="DataValueField"></param>
        public static void LoadDDL(this DropDownList ddl, object dataSource, string dataTextField, string DataValueField, bool addDefaultValue)
        {
            Rwd.Framework.Web.Controls.LoadDDL(ref ddl, dataSource, dataTextField, DataValueField, addDefaultValue);
        }

        /// <summary>
        /// Loads DropDownlist, and adds a default item
        /// </summary>
        /// <param name="lb"></param>
        /// <param name="dataSource"></param>
        /// <param name="dataTextField"></param>
        /// <param name="DataValueField"></param>
        /// <param name="defaultText"></param>
        /// <param name="defaultValue"></param>
        public static void LoadDDL(this DropDownList ddl, object dataSource, string dataTextField, string DataValueField, string defaultText, string defaultValue)
        {
            Rwd.Framework.Web.Controls.LoadDDL(ref ddl, dataSource, dataTextField, DataValueField, defaultText, defaultValue);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="lb"></param>
        /// <param name="dataSource"></param>
        /// <param name="dataTextField"></param>
        public static void LoadListBox(this ListBox lb, object dataSource, string dataTextField)
        {
            Rwd.Framework.Web.Controls.LoadListBox(ref lb, dataSource, dataTextField);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="lb"></param>
        /// <param name="dataSource"></param>
        /// <param name="dataTextField"></param>
        /// <param name="DataValueField"></param>
        public static void LoadListBox(this ListBox lb, object dataSource, string dataTextField, string DataValueField)
        {
            Rwd.Framework.Web.Controls.LoadListBox(ref lb, dataSource, dataTextField, DataValueField);
        }

        /// <summary>
        /// Sets SelectedValue of the checkboxlist
        /// allows for any object type with ToString() to be passed in 
        /// tries to set the SelectedValue within a try catch, so an error is not thrown
        /// if the value doesn't exist
        /// </summary>
        /// <param name="ddl"></param>
        /// <param name="value"></param>
        public static void Set(this CheckBoxList obj, object value)
        {
            try { obj.SelectedValue = value.ToString(); }
            catch { }
        }

        /// <summary>
        /// Sets SelectedValue of the dropdownlist 
        /// allows for any object type with ToString() to be passed in 
        /// tries to set the SelectedValue within a try catch, so an error is not thrown
        /// if the value doesn't exist
        /// </summary>
        /// <param name="ddl"></param>
        /// <param name="value"></param>
        public static void Set(this DropDownList obj, object value)
        {
            try { obj.SelectedValue = value.ToString(); }
            catch { }
        }

        /// <summary>
        /// Sets SelectedValue of the radiobuttonlist
        /// allows for any object type with ToString() to be passed in 
        /// tries to set the SelectedValue within a try catch, so an error is not thrown
        /// if the value doesn't exist
        /// </summary>
        /// <param name="ddl"></param>
        /// <param name="value"></param>
        public static void Set(this RadioButtonList obj, object value)
        {
            try { obj.SelectedValue = value.ToString(); }
            catch { }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="gridView"></param>
        public static void ToExcel(this GridView gridView)
        {
            Rwd.Framework.Web.Controls.GridViewToExcel(gridView);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="gridView"></param>
        public static void ToExcel(this GridView gridView, string fileName)
        {
            Rwd.Framework.Web.Controls.GridViewToExcel(gridView, fileName);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="lb"></param>
        /// <returns></returns>
        public static IEnumerable<ListItem> Where(this CheckBoxList obj, Func<ListItem, bool> predicate)
        {
            return obj.Items.Where(predicate);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="lb"></param>
        /// <returns></returns>
        public static IEnumerable<ListItem> Where(this DropDownList obj, Func<ListItem, bool> predicate)
        {
            return obj.Items.Where(predicate);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="lb"></param>
        /// <returns></returns>
        public static IEnumerable<ListItem> Where(this ListItemCollection lic, Func<ListItem, bool> predicate)
        {
            return lic.Cast<ListItem>().Where(predicate);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="lb"></param>
        /// <returns></returns>
        public static IEnumerable<ListItem> Where(this ListBox obj, Func<ListItem, bool> predicate)
        {
            return obj.Items.Where(predicate);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="lb"></param>
        /// <returns></returns>
        public static IEnumerable<ListItem> Where(this RadioButtonList obj, Func<ListItem, bool> predicate)
        {
            return obj.Items.Where(predicate);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="lb"></param>
        /// <returns></returns>
        public static IEnumerable<GridViewRow> Where(this GridView obj, Func<GridViewRow, bool> predicate)
        {
            return obj.Columns.Cast<GridViewRow>().Where(predicate);
        }

    }
}
