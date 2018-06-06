using Models.Interfaces;
using Models;
using System.Windows;
using System.Windows.Controls;
using System;

namespace Views
{

    public partial class FilmOverview : UserControl, ISwitch
    {
        public FilmOverview(Film film)
        {
            InitializeComponent();
            DataContext = film ?? throw new ArgumentNullException("Le film à afficher est null :(");
        }

        /// <summary>
        /// Fonction appellée quand on clique sur le bouton retour
        /// </summary>
        private void Return_Button_Click(object sender, RoutedEventArgs e)
        {
            Switch(new FilmView(), false);
        }

        public void Switch(UserControl uc, bool sidebar = true) => ControlSwitcher.Switch(uc, sidebar);
    }
}
