using System;
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
        [TestMethod]
        public void InsertFilmSuccess()
        {
            db.Insert(new Film("Bonjour", "Hasbani", DateTime.Now));

            var films = StockageBDD.GetFilms();

            Assert.IsNotNull(films);
            Assert.IsTrue(films.Count() > 0);
        }
    }
}
