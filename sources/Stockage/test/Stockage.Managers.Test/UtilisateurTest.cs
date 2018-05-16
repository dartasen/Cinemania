using Managers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models;

namespace Stockage.Managers.Test
{
    [TestClass]
    public class UtilisateurTest
    {
        /// <summary>
        /// Vérifie si l'insertion des utilisateurs fonctionne correctement
        /// * Test des insertions
        /// * Comptage dans la base de donnée via LinQ
        /// </summary>
        [TestMethod]
        public void CreateUsersSuccess()
        {
            var db = StockageBDD.Init();

            int test = -1;

            for (int i = 0; i < 5; i++)
            {
                test = db.Insert(new Utilisateur("pseudo" + i, "Nom" + i, "Prenom" + i, "123soleil"));
                Assert.IsTrue(test > 0);
            }

            Assert.IsTrue(db.Table<Utilisateur>().Count() > 0);
        }

        /// <summary>
        /// Vérifie si la sélection dans la Base De Donnée avec LinQ fonctionne
        /// * Test des insertions
        /// </summary>
        [TestMethod]
        public void LinQBeyondUsersSuccess()
        {
            var db = StockageBDD.Init();

            int test = db.Insert(new Utilisateur("toto", "titi", "titi", "1234", true));

            Assert.IsTrue(test > 0);
            Assert.IsNotNull(value: db.Get<Utilisateur>(u => u.IsAdmin == true));
            Assert.IsNotNull(value: db.Table<Utilisateur>().Select<string>(u => u.Nom));
        }
    }
}
