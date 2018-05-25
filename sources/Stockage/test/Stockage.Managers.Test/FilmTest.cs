﻿using System;
using System.Linq;
using Managers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models;
using SQLite;

namespace Stockage.Managers.Test
{
    [TestClass]
    public class FilmTest
    {
        public SQLiteConnection db = StockageBDD.Init();

        /// <summary>
        /// Vérifie l'insertion d'un film dans la Base De Donnée
        /// </summary>
        [TestMethod, Priority(1)]
        public void InsertFilmSuccess()
        {
            db.Insert(new Film("Bonjour", "Hasbani", Categorie.THRILL, DateTime.Now));
            db.Insert(new Film("Bonjoure", "Hsbani", Categorie.ACTION, DateTime.Now));
            db.Insert(new Film("Bonjourd", "Hasni", Categorie.ACTION, DateTime.Now));
            db.Insert(new Film("Bonjourf", "Hasani", Categorie.AVENTURE, DateTime.Now));
            db.Insert(new Film("Bonoure", "Hsbni", Categorie.ACTION, DateTime.Now));
            db.Insert(new Film("Bonjourg", "Hasbni", Categorie.FANTAISIE, DateTime.Now));

            var films = StockageBDD.GetFilms();
            Assert.IsNotNull(films);
            Assert.IsTrue(films.Count() > 0);

            var film = StockageBDD.CheckFilm(1);

            Assert.IsNotNull(film);
        }

        /// <summary>
        /// Vérifie si l'on peut récupérer correctement un dictionnary associant une catégorie à sa liste de film
        /// </summary>
        [TestMethod]
        public void GetFilmsByCategoriesSuccess()
        {
            var dico = StockageBDD.GetFilmsByCategorie();

            Assert.IsNotNull(dico);
        }
    }
}
