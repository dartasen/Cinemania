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

            db = new SQLiteConnection("data source=" + DatabaseFile);
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
