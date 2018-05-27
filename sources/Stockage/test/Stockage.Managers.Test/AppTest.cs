using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models;
using SQLite;
using Views;

namespace Managers.Test
{
    [TestClass]
    public class AppTest
    {
        protected static SQLiteConnection db = StockageBDD.Init();

        /// <summary>
        /// On teste un cas aux limites en essayant de changer de vue 
        /// sur ControlSwitcher sans avoir instancier le Main à l'intérieur
        /// </summary>
        [TestMethod, ExpectedException(typeof(Exception))]
        public void SwitchViewFailed() => ControlSwitcher.Switch(new ConnectionView());

        /// <summary>
        /// On test un autre cas aux limites en essayant de changer de vue
        /// mais en donnant null comme vue à afficher
        /// </summary>
        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void SwitchUserControlFailed() => ControlSwitcher.Switch(null);
    }
}
