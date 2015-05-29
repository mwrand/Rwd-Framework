using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Rwd.Framework.Extensions
{
    public static class DataTableExtension1
    {
        public static DataTable ToDataTable<T>(this List<T> list)
        {
            var type = typeof(T);
            var dt = new DataTable(type.Name);

            var propertyInfos = type.GetProperties().ToList();

            //For each property of generic List (T), add a column to table
            propertyInfos.ForEach(propertyInfo =>
            {
                var columnType = Nullable.GetUnderlyingType(propertyInfo.PropertyType) ?? propertyInfo.PropertyType;
                dt.Columns.Add(propertyInfo.Name, columnType);
            });


            //Visit every property of generic List (T) and add each value to the data table 
            list.ForEach(item =>
            {
                var row = dt.NewRow();
                propertyInfos.ForEach(
                                       propertyInfo =>
                                       row[propertyInfo.Name] = propertyInfo.GetValue(item, null) ?? DBNull.Value
                                     );
                dt.Rows.Add(row);
            });

            //Return the datatable
            return dt;
        }
    }
}
