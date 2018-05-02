using Styles;
using System.Windows;
using System.Windows.Controls;
using Views;

namespace Models
{
    public static class PageSwitcher
    {
        public static MainView pageSwitcher;

        public static void Switch(UserControl newPage)
        {
            if (pageSwitcher != null) {
                pageSwitcher.Navigate(newPage);
            } else {
                throw new System.Exception("L'instance du pageSwitcher principal n'a pas été défini !");
            }
        }
    }
}
