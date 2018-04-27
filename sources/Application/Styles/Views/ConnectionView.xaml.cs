using Interfaces;
using Models;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Views
{
    public partial class ConnectionView : UserControl, ISwitch
    {

        public ConnectionView()
        {
            InitializeComponent();
            DataContext = this;
        }

        public void Button_Click(object sender, RoutedEventArgs args)
        {
            Switch(new MenuView());
        }

        public void Switch(UserControl uc)
        {
            PageSwitcher.Switch(uc);
        }
    }
}
