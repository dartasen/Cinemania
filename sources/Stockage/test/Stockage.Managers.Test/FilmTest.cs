using System;
using System.Linq;
using Managers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models;

namespace Stockage.Managers.Test
{
    [TestClass]
    public class FilmTest
    {
        /// <summary>
        /// Vérifie l'insertion d'un film dans la Base De Donnée
        /// </summary>
        [TestMethod]
        public void InsertFilmSuccess()
        {
            var db = StockageBDD.Init();

            db.Insert(new Film("Bonjour", "Hasbani", DateTime.Now));

            var films = StockageBDD.GetFilms();

            Assert.IsNotNull(films);
            Assert.IsTrue(films.Count() > 0);
        }
    }
}
