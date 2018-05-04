using System;
using SQLite;
using System.IO;
using Models;
using System.Collections.ObjectModel;
using System.Collections.Generic;

namespace Managers
{
    public static class StockageBDD
    {
        private const string DatabaseFile = "db.sqlite";
        public static SQLiteConnection Database { get; private set; }

        public static SQLiteConnection Init()
        {
            if (Database != null)
                return Database;

            File.Delete(DatabaseFile);

            Database = new SQLiteConnection(DatabaseFile);

            if (Database == null)
                throw new Exception("Impossible d'établir une connexion avec la base de donnée :(");

            Database.CreateTable<Utilisateur>();
            Database.CreateTable<Film>();

            return Database;
        }

        public static int Insert<T>(T u)
        {
            return Database.Insert(u);
        }

        public static bool CheckUser(string pseudo, string mdp)
        {
            var query = Database.Table<Utilisateur>().Where(u => u.Pseudo.Equals(pseudo) && u.Password.Equals(mdp));

            return query.Count() == 1;
        }
         
        public static ObservableCollection<Film> GetFilms()
        {
            var list = Database.Query<Film>("SELECT * FROM Film ORDER BY titre");

            return new ObservableCollection<Film>(list);
        }
    }

}
