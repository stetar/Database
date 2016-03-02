using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Data.SQLite;
using System.Diagnostics;

namespace Working_title
{
    class LoginDBManager
    {
        SQLiteConnection dbConn;


        public void CreateOrConnectDB()
        {
            if(File.Exists("AccountDB.db"))
            {
                dbConn = new SQLiteConnection("Data Source=AccountDB.db;Version=3;");
                dbConn.Open();
            }
            else
            {
                SQLiteConnection.CreateFile("AccountDB.db"); 

                dbConn = new SQLiteConnection("Data Source=AccountDB.db;Version=3;"); 
                dbConn.Open();

                String sqlCreateTbl = "create table Accounts (username varchar(20), password varchar(20))"; 
                SQLiteCommand createTblCommand = new SQLiteCommand(sqlCreateTbl, dbConn);
                createTblCommand.ExecuteNonQuery();
            }
        }


        public bool Register(string checkingWishedName, string checkingWishedPassword)
        {
            CreateOrConnectDB();
            
            string sqlAccountCheck = "select count(username) from 'Accounts' where username = '" + checkingWishedName + "'";
            SQLiteCommand readCommand = new SQLiteCommand(sqlAccountCheck, dbConn);
            SQLiteDataReader reader = readCommand.ExecuteReader();
            while (reader.Read())
            {
                int Count = reader.GetInt32(0);
                Debug.Assert(Count <= 0, "Wished name is not free, try another!");
                

                if(Count <= 0)
                {
                    string sqlInsert = "insert into Accounts (username, password) values ('"+checkingWishedName+"','"+checkingWishedPassword+"')";
                    SQLiteCommand insertCommand = new SQLiteCommand(sqlInsert, dbConn);
                    insertCommand.ExecuteNonQuery();

                    Game1.CurrentGameState = GameState.MainMenu;
                    return true;
                }
            }
            return false;
        }
        
        public void Login(string checkingName, string checkingPassword)
        {
            CreateOrConnectDB();

            string sqlNamePasswordCheck = "select count (*) from 'Accounts' where username = '" + checkingName + "' AND password = '" + checkingPassword + "'";
            SQLiteCommand readCommand = new SQLiteCommand(sqlNamePasswordCheck, dbConn);
            SQLiteDataReader reader = readCommand.ExecuteReader();

            while (reader.Read())
            {
                int Count = reader.GetInt32(0);
                Debug.Assert(Count > 0, "Name and/or passowrd is not correct!");

                if (Count > 0)
                {
                    Game1.CurrentGameState = GameState.MainMenu;
                }
            }
        }

    }
}
