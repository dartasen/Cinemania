using Models;
using Models.Interfaces;
using System.Windows;
using System.Windows.Controls;

namespace Views
{
    public partial class ButtonList : UserControl, ISwitch
    {
        public ButtonList()
        {
            InitializeComponent();
        }

        private void Film_Click(object sender, RoutedEventArgs e)
        {
            Switch(new FilmView(), false);
        }

        private void Categorie_Click(object sender, RoutedEventArgs e)
        {
            Switch(new CategorieView(), false);
        }

        public void Switch(UserControl uc, bool sidebar = true) => ControlSwitcher.Switch(uc, sidebar);
    }
}
