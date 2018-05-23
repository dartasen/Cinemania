using System;
using SQLite;
using System.IO;
using Models;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;

namespace Managers
{
    public static class StockageBDD
    {
        private const string DatabaseFile = "db.sqlite";
        public static SQLiteConnection Database { get; private set; }

        /// <summary>
        /// Initialise la base de donnée SQLITE
        /// </summary>
        /// 
        /// <exception cref="Exception">Exception déclenchée quand la Base de Donnée ne peut-être créée</exception>
        /// <returns>Retourne une instance unique de la Base De Donnée</returns>
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

        /// <summary>
        /// Permet d'insérer un objet dans la base de donnée
        /// </summary>
        /// 
        /// <typeparam name="T">Le type objet qui visera une table de la base de donnée</typeparam>
        /// <param name="u">L'objet a inséré</param>
        /// <returns>Retourne un nombre signifiant l'état de l'insertion</returns>
        public static int Insert<T>(T u) => Database.Insert(u);

        /// <summary>
        /// Vérifie si un doublon pseudo/mdp existe dans la Base De Donnée
        /// </summary>
        /// 
        /// <param name="pseudo">Le pseudo</param>
        /// <param name="mdp">Le mot de passe</param>
        /// <returns>Retourne l'utilisateur correspondant au doublon</returns>
        public static Utilisateur CheckUser(string pseudo, string mdp)
        {
            var query = Database.Table<Utilisateur>().Where(u => u.Pseudo.Equals(pseudo) && u.Password.Equals(mdp));

            if (query.Count() > 0)
            {
                return query.First();
            }

            return null;
        }

        /// <summary>
        /// Vérifie si un utilisateur existe déjà dans la Base De Donnée
        /// </summary>
        /// 
        /// <param name="pseudo">Le pseudo de l'utilisateur</param>
        /// <returns>Retourne "true" si l'utilisateur existe sinon "false"</returns>
        public static bool CheckIfUserExists(string pseudo)
        {
            var query = Database.Table<Utilisateur>().Where(u => u.Pseudo.Equals(pseudo));

            if (query.Count() > 0)
            {
                return true;
            }

            return false;
        }
        
        /// <summary>
        /// Retourne la liste de film contenue dans la Base De Donnée
        /// </summary>
        /// 
        /// <returns>La collection observable des films</returns>
        public static ObservableCollection<Film> GetFilms()
        {
            var list = Database.Query<Film>("SELECT * FROM Film ORDER BY titre");
            return new ObservableCollection<Film>(list);
        }

        /// <summary>
        /// Retourne un dictionnaire associant une catégories à ses films
        /// </summary>
        /// 
        /// <returns>Le dictionnaire</returns>
        public static Dictionary<Categorie, List<Film>> GetFilmsByCategorie()
        {
            Dictionary<Categorie, List<Film>> dico = new Dictionary<Categorie, List<Film>>();
            var categories = Enum.GetValues(typeof(Categorie)).Cast<Categorie>().ToList();

            foreach (Categorie e in categories)
            {
                var film = Database.Table<Film>().Where(f => f.Categorie.Equals(e));
                List<Film> value = new List<Film>();

                value.AddRange(film.ToList());
                dico.Add(e, value);
            }

            return dico;
        }
    }

}
