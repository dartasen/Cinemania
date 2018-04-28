using System;
using managers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models;

namespace Stockage.Managers.Test
{
    [TestClass]
    public class UtilisateurTest
    {
        [TestMethod]
        public void CreateUtilisateurSuccess()
        {
            var db = new StockageBDD();
            int pk = db.InsertUser(new Utilisateur("uhue", "ihie", "25545"));

            Assert.IsTrue(pk > 0);
        }
    }
}
