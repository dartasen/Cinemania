using Models.Interfaces;
using Managers;
using Models;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace Views
{
    public partial class FilmManagerView : UserControl, ISwitch
    {
        /// <summary>
        /// La liste des films à afficher
        /// </summary>
        public Collection<Film> Films { get; } = StockageBDD.GetFilms();

        public FilmManagerView()
        {
            InitializeComponent();
            DataContext = this;
        }

        public void Switch(UserControl uc, bool sidebar = true) => ControlSwitcher.Switch(uc, sidebar);
    }
}
