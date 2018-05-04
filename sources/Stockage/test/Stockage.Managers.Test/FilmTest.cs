using System;
using Managers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Stockage.Managers.Test
{
    [TestClass]
    public class FilmTest
    {
        [TestMethod]
        public void InsertFilmSuccess()
        {
            var db = StockageBDD.Init();
        }
    }
}
