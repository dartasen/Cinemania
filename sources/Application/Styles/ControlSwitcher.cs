using System;
using System.Windows.Controls;
using Views;

namespace Models
{
    public static class ControlSwitcher
    {
        public static MainView main;

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
