using Interfaces;
using Models;
using System.Windows;
using System.Windows.Controls;

namespace Views
{
    public partial class MenuView : UserControl, ISwitch
    {
        public MenuView()
        {
            InitializeComponent();
        }

        public void Button_Click(object sender, RoutedEventArgs args)
        {
            Switch(new ConnectionView());
        }

        public void Switch(UserControl uc)
        {
            PageSwitcher.Switch(uc);
        }
    }
}
