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
        /// <param name="uc">Le UserControl a afficher</param>
        public static void Switch(UserControl uc, bool sidebar = true)
        {
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
