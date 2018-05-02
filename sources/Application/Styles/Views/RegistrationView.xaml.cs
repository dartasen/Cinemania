using Interfaces;
using Models;
using System.Windows;
using System.Windows.Controls;

namespace Styles.Views
{
    public partial class RegistrationView : UserControl, ISwitch
    {
        public RegistrationView()
        {
            InitializeComponent();
        }

        private void Registration_Click(object sender, RoutedEventArgs e)
        {

        }

        public void Switch(UserControl uc) => PageSwitcher.Switch(uc);
    }
}
