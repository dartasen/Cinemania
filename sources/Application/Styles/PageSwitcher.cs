using Styles;
using System.Windows.Controls;
using Views;

namespace Models
{
    public static class PageSwitcher
    {
        public static MainView pageSwitcher;

        public static void Switch(UserControl newPage)
        {
            pageSwitcher.Navigate(newPage);
        }
    }
}
