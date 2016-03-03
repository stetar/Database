using System.Data.SQLite;
using System.IO;

namespace Working_title.DataBase
{
    public class DataBaseConnector
    {
        private SQLiteConnection DatabaseConnection;

        public SQLiteConnection Connect(string databasePath)
        {
            if (File.Exists(databasePath))
            {
                DatabaseConnection = new SQLiteConnection("Data Source="+ databasePath+";Version=3;");
                DatabaseConnection.Open();
                return DatabaseConnection;
            }
            return null;
        }
    }
}