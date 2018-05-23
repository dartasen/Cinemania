using Interfaces;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using Models;
using Styles.Views;
using System.Windows;
using System.Windows.Controls;

namespace Views
{
    public partial class MenuView : UserControl, ISwitch
    {
        public MenuView()
        {
            InitializeComponent();

            if (MainView.CurrentUser.IsAdmin)
                this.admin_Btn.Visibility = Visibility.Visible;
        }

        /// <summary>
        /// Méthode appelée quand on clique sur le bouton déconnexion
        /// </summary>
        private void Logout_Click(object sender, RoutedEventArgs args)
        {
            MainView.CurrentUser = null;
            Switch(new ConnectionView()); 
        }

        /// <summary>
        /// Méthode appelée quand on clique sur le bouton Mon compte
        /// </summary>
        private void Account_Click(object sender, RoutedEventArgs e)
        {
            var win = (Application.Current.MainWindow as MetroWindow);
            win.ShowMessageAsync("404 NOT FOUND", "Cette fonctionnalité n'est pas encore implémenté :(");
        }

        /// <summary>
        /// Méthode appelée quand on clique sur le bouton Favoris
        /// </summary>
        private void Favoris_Click(object sender, RoutedEventArgs e)
        {
            var win = (Application.Current.MainWindow as MetroWindow);
            win.ShowMessageAsync("404 NOT FOUND", "Cette fonctionnalité n'est pas encore implémenté :(");
        }

        /// <summary>
        /// Méthode appelée quand on clique sur le bouton Administration
        /// </summary>
        private void Admin_Click(object sender, RoutedEventArgs e)
        {
            Switch(new FilmManagerView(), false);
        }

        public void Switch(UserControl uc, bool sidebar = true) => ControlSwitcher.Switch(uc, sidebar);
    }
}
