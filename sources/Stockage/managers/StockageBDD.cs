using System;
using System.Data.SQLite;
using System.IO;

namespace managers
{
    public class StockageBDD
    {
        private const string DatabaseFile = "db.sqlite";
        private SQLiteConnection db;

        public StockageBDD()
        {
            if (!File.Exists(DatabaseFile))
            {
                SQLiteConnection.CreateFile(DatabaseFile);
            }

            db = new SQLiteConnection("Data Source=" + DatabaseFile + ";Version=3;");
        }

        public void Query(String command)
        {
            db.Open();

            var sql = new SQLiteCommand(command, db);
            sql.ExecuteNonQuery();

            db.Close();
        }

    }

}
