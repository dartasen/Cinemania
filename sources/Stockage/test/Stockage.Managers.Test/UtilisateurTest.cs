using System;
using System.Collections.Generic;
using managers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models;

namespace Stockage.Managers.Test
{
    [TestClass]
    public class UtilisateurTest
    {
        [TestMethod]
        public void CreateUsersSuccess()
        {
            var db = new StockageBDD().Database;
            int test = -1;

            for (int i = 0; i < 5; i++)
            {
                test = db.Insert(new Utilisateur("Nom" + i, "Prenom" + i, "123soleil"));
                Assert.IsTrue(test > 0);
            }

            Assert.IsTrue(db.Table<Utilisateur>().Count() == 4);
        }

        [TestMethod]
        public void LinQBeyondUsersSuccess()
        {
            var db = new StockageBDD().Database;

            var selectUser = db.Get<Utilisateur>(u => u.IsAdmin);
            var selectUser2 = db.Table<Utilisateur>().Select<string>(u => u.Nom);

            Assert.IsNotNull(selectUser);
            Assert.IsNotNull(selectUser2);
        }
    }
}
