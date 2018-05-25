using Interfaces;
using Managers;
using Models;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace Views
{
    public partial class FilmView : UserControl, ISwitch
    {
        public ObservableCollection<Film> ListeFilms { get; private set; } = StockageBDD.GetFilms();

        private Film _selectedFilm;
        public Film SelectedFilm
        {
            get
            {
                return _selectedFilm;
            }
           
            set
            {
                _selectedFilm = value;
                Switch(new FilmOverview(value), false);
            }
        }

        public FilmView()
        {
            InitializeComponent();
            DataContext = this;
        }

        public void Switch(UserControl uc, bool sidebar = true) => ControlSwitcher.Switch(uc, sidebar);
    }
}
