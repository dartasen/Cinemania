using System;
using SQLite;
using System.IO;
using Models;

namespace managers
{
    public class StockageBDD
    {
        private const string DatabaseFile = "db.sqlite";
        public SQLiteConnection Database { get; private set; }
        
        public StockageBDD()
        {
            Database = new SQLiteConnection(DatabaseFile);
            Database.CreateTable<Utilisateur>();
            Database.CreateTable<Film>();
        }

        public int InsertUser(Utilisateur u)
        {
            return Database.Insert(u);
        }
    }

}
