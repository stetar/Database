using System.Collections.Generic;

namespace Working_title.DataBase
{
    public class ColumnData
    {
        public string ColumnName;
        public List<object> ColumnValues;
        

        public ColumnData(string columnName, List<object> columnValues)
        {
            ColumnName = columnName;
            ColumnValues = columnValues;
        }
    }
}