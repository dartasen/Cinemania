using System;
using System.Windows.Controls;
using Views;

namespace Models
{
    public static class ControlSwitcher
    {
        /// <summary>
        /// L'instance du MainWindow
        /// </summary>
        public static MainView main;

        /// <summary>
        /// Permet de contrôler le UserControl dans le ContentPresenter de la MainWindow
        /// </summary>
        /// 
        /// <param name="newPage">Le UserControl a afficher</param>
        public static void Switch(UserControl newPage)
        {
            if (main != null)
            {
                main.Navigate(newPage);
            }
            else
            {
                throw new Exception("L'instance du pageSwitcher principal n'a pas été défini !");
            }
        }
    }
}
