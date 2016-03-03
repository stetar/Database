using System.Collections.Generic;
using System.Data.SQLite;

namespace Working_title.DataBase
{
    public class DatabaseReader
    {
        private SQLiteConnection SqlDatabaseConnectionConnection;
        private string SqlQuery;

        public DatabaseReader(SQLiteConnection sqlDatabaseConnectionConnection,string sqlQuery)
        {
            SqlDatabaseConnectionConnection = sqlDatabaseConnectionConnection;
            SqlQuery = sqlQuery;
        }

        public object GetColumnValue(string columnName)
        {
            SQLiteDataReader DataReader = GetDataReader(SqlQuery);
            DataReader.Read();
            return DataReader[columnName];
        }

        public List<object> GetColumnValues(string columnName)
        {
            List<object> ColumnValues = new List<object>();
            SQLiteDataReader DataReader = GetDataReader(SqlQuery);
            while (DataReader.Read())
            {
                ColumnValues.Add(DataReader[columnName]);
            }
            return ColumnValues;
        }

        public List<ColumnData> GetColumnsValues(List<string> columnNames)
        {
            List<ColumnData> ColumnsValues = new List<ColumnData>();
          
            foreach (var ColumnName in columnNames)
            {
                ColumnsValues.Add(new ColumnData(ColumnName, GetColumnValues(ColumnName)));
            }
            
            return ColumnsValues;
        }


        public SQLiteDataReader GetDataReader(string sqlQuery)
        {
            SQLiteCommand ReadCommand = new SQLiteCommand(sqlQuery, SqlDatabaseConnectionConnection);
            return ReadCommand.ExecuteReader();
        }
    }
}