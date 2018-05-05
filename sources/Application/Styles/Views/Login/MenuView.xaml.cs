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

        public void Logout_Click(object sender, RoutedEventArgs args)
        {
            Switch(new ConnectionView()); 
        }

        private void Account_Click(object sender, RoutedEventArgs e)
        {
            var win = (Application.Current.MainWindow as MetroWindow);

            win.ShowLoginAsync("test", "salut bg");
        }

        public void Switch(UserControl uc) => ControlSwitcher.Switch(uc);
    }
}
