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

        private void Logout_Click(object sender, RoutedEventArgs args)
        {
            MainView.CurrentUser = null;
            Switch(new ConnectionView()); 
        }

        private void Account_Click(object sender, RoutedEventArgs e)
        {
            var win = (Application.Current.MainWindow as MetroWindow);

     
        }

        private void Favoris_Click(object sender, RoutedEventArgs e)
        {

        }

        public void Switch(UserControl uc) => ControlSwitcher.Switch(uc);
    }
}
