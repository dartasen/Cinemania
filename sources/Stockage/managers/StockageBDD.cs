﻿using System;
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
        /// Initialise la base de données en SQLITE
        /// </summary>
        /// 
        /// <exception cref="Exception">Exception déclenchée quand la Base de Données ne peut-être créée</exception>
        /// <returns>Retourne une instance unique de la Base De Données</returns>
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

            //TODO : Insertion à virer après les tests
            Insert<Utilisateur>(new Utilisateur("test", "MF", "S", "test"));
            Insert<Utilisateur>(new Utilisateur("admin", "ad", "min", "admin", true));
            Insert<Film>(new Film("Solo : A StarWars Story", "Ron Howard", Categorie.SCIENCEFICTION, DateTime.Now, 0));
            Insert<Film>(new Film("Deadpool 2", "David Leitch", Categorie.ACTION, DateTime.Now, 1));
            Insert<Film>(new Film("Avengers 3 : Infinity War", "Marvel Studios", Categorie.ACTION, DateTime.Now, 2));
            Insert<Film>(new Film("Ready Player One", "Steven Spielberg", Categorie.SCIENCEFICTION, DateTime.Now, 3));
            Insert<Film>(new Film("13 RW", "Jay Asher", Categorie.THRILL, DateTime.Now, 4));
            //

            return Database;
        }

        /// <summary>
        /// Permet d'insérer un objet dans la base de données
        /// </summary>
        /// 
        /// <typeparam name="T">Le type objet qui visera une table de la base de donnée</typeparam>
        /// <param name="u">L'objet a inséré</param>
        /// 
        /// <exception cref="ArgumentNullException">Exception déclenchée quand l'objet a inséré est null</exception>
        /// <returns>Retourne un nombre signifiant l'état de l'insertion</returns>
        public static int Insert<T>(T u)
        {
            if (u == null)
                throw new ArgumentNullException(nameof(u));

            return Database.Insert(u);
        }


        /// <summary>
        /// Retourne la liste des utilisateurs contenus dans la Base De Données
        /// </summary>
        /// 
        /// <returns>La collection observable des utilisateurs</returns>
        public static ObservableCollection<Utilisateur> GetUsers()
        {
            List<Utilisateur> list = new List<Utilisateur>();

            try
            {
                var temp = Database.Query<Utilisateur>("SELECT * FROM Utilisateur ORDER BY id");
                list.AddRange(temp);
            }
            catch (Exception) { }

            return new ObservableCollection<Utilisateur>(list);
        }
        /// <summary>
        /// Vérifie si un doublon pseudo/mdp existe dans la Base De Données
        /// </summary>
        /// 
        /// <param name="pseudo">Le pseudo</param>
        /// <param name="mdp">Le mot de passe</param>
        /// <returns>Retourne l'utilisateur correspondant au doublon</returns>
        public static Utilisateur CheckUser(string pseudo, string mdp)
        {
            if (string.IsNullOrEmpty(pseudo) || string.IsNullOrEmpty(mdp))
            {
                return null;
            }

            var query = Database.Table<Utilisateur>().Where(u => u.Pseudo.Equals(pseudo) && u.Password.Equals(mdp));

            if (query.Count() > 0)
            {
                return query.First();
            }

            return null;
        }

        /// <summary>
        /// Vérifie si un utilisateur existe déjà dans la Base De Données
        /// </summary>
        /// 
        /// <param name="pseudo">Le pseudo de l'utilisateur</param>
        /// <returns>Retourne "true" si l'utilisateur existe sinon "false"</returns>
        public static bool CheckIfUserExists(string pseudo)
        {
            if (string.IsNullOrEmpty(pseudo))
            {
                return false;
            }

            var query = Database.Table<Utilisateur>().Where(u => u.Pseudo.Equals(pseudo));

            if (query.Count() > 0)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Vérifie si le film existe dans la base de données
        /// </summary>
        /// 
        /// <param name="id">id du film</param>
        /// <returns>Retourne l'utilisateur correspondant au doublon</returns>
        public static Film CheckFilm(int id)
        {
            if (id < 0)
            {
                return null;
            }

            var query = Database.Table<Film>().Where(f => f.Id.Equals(id));

            if (query.Count() > 0)
            {
                return query.First();
            }

            return null;
        }

        /// <summary>
        /// Retourne la liste des films contenue dans la Base De Données
        /// </summary>
        /// 
        /// <returns>La collection observable des films</returns>
        public static ObservableCollection<Film> GetFilms(Categorie cat = Categorie.DEFAUT)
        {
            List<Film> list = new List<Film>();

            try
            {
                var temp = Database.Query<Film>("SELECT * FROM Film ORDER BY titre");
                list.AddRange(temp);
            } catch (Exception) { }

            if (cat != Categorie.DEFAUT)
            {
                list = list.Where(f => f.Categorie.Equals(cat)).ToList();
            }

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

                if (film != null)
                    value.AddRange(film);

                dico.Add(e, value);
            }

            return dico;
        }
    }

}
