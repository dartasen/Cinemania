using Managers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models;
using SQLite;

namespace Stockage.Managers.Test
{
    [TestClass]
    public class UtilisateurTest
    {

        public SQLiteConnection db = StockageBDD.Init();

        /// <summary>
        /// Vérifie que l'insertion des utilisateurs fonctionne correctement
        /// </summary>
        [TestMethod, Priority(2)]
        public void CreateUserSuccess()
        {
            int test = -1;

            for (int i = 0; i < 2; i++)
            {
                test = db.Insert(new Utilisateur("pseudo" + i, "Nom" + i, "Prenom" + i, "123soleil"));
                Assert.IsTrue(test > 0);
            }

            Assert.IsTrue(db.Table<Utilisateur>().Count() > 0);
        }

        /// <summary>
        /// Vérifie que la sélection dans la Base De Donnée avec LinQ via l'interface des tables fonctionne
        /// </summary>
        [TestMethod, Priority(1)]
        public void LinQBeyondUsersSuccess()
        {
            int test = db.Insert(new Utilisateur("toto", "titi", "titi", "1234", true));

            Assert.IsTrue(test > 0);
            Assert.IsNotNull(value: db.Get<Utilisateur>(u => u.IsAdmin == true));
            Assert.IsNotNull(value: db.Table<Utilisateur>().Select<string>(u => u.Nom));
        }

        /// <summary>
        /// Verifie si le mécanisme de login fonctionne
        /// </summary>
        [TestMethod]
        public void UserLoginSuccess()
        {
            Utilisateur connect;

            connect = StockageBDD.CheckUser("pseudo0", "123soleil");
            Assert.IsNotNull(connect);

            connect = StockageBDD.CheckUser("admin", "uselessmdp");
            Assert.IsNull(connect);
        }

        /// <summary>
        /// Vérifie si un utilisateur existe dans la database
        /// </summary>
        [TestMethod]
        public void CheckUserExist()
        {
            bool exist;

            exist = StockageBDD.CheckIfUserExists("pseudo0");
            Assert.IsTrue(exist);

            db.Table<Utilisateur>().Delete(u => u.Pseudo.Equals("pseudo0"));
            exist = StockageBDD.CheckIfUserExists("pseudo0");
            Assert.IsFalse(exist);

            db.Table<Utilisateur>().Delete(u => u.Pseudo.Equals("pseudo1"));
            exist = StockageBDD.CheckIfUserExists("pseudo1");
            Assert.IsFalse(exist);

            db.Table<Utilisateur>().Delete(u => u.Pseudo.Equals("toto"));
            exist = StockageBDD.CheckIfUserExists("toto");
            Assert.IsFalse(exist);
        }
    }
}
