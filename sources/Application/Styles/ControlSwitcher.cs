using Interfaces;
using System;
using System.Windows.Controls;
using Views;

namespace Models
{
    public class ControlSwitcher
    {
        /// <summary>
        /// L'instance du MainWindow
        /// </summary>
        public static MainView Main { private get; set; }

        /// <summary>
        /// Permet de contrôler le UserControl dans le ContentPresenter de la MainWindow
        /// </summary>
        /// 
        /// <exception cref="ArgumentNullException">Déclenché si le UserControl est "null"</exception>
        /// <exception cref="ArgumentException">Déclenché si le UserControl n'est pas <see cref="ISwitch"/></exception>
        /// <exception cref="Exception">Déclenché si l'instance du main est "null"</exception>
        /// 
        /// <param name="uc">Le UserControl a afficher</param>
        public static void Switch(UserControl uc, bool sidebar = true)
        {
            if (uc == null)
                throw new ArgumentNullException("Le UserControl ne peut-être nul pour la navigation");
            else if (!(uc is ISwitch)) {
                throw new ArgumentException("Le UserControl n'implémente pas l'interface ISwitch");
            }

            if (Main != null)
            {
                Main.Navigate(uc, sidebar);
            }
            else
            {
                throw new Exception("L'instance du pageSwitcher principal n'a pas été défini !");
            }
        }
    }
}
