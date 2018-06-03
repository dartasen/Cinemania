using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using Managers;
using Models;
using Models.Interfaces;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Views
{
    public partial class FilmView : UserControl, ISwitch
    {
        public ObservableCollection<Film> ListeFilms { get; private set; }

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

        public FilmView(Categorie cat = Categorie.DEFAUT)
        {
            InitializeComponent();
            DataContext = this;

            ListeFilms = StockageBDD.GetFilms(cat);

            if (cat != Categorie.DEFAUT)
            {
                if (ListeFilms.Count() == 0)
                {
                    var win = (Application.Current.MainWindow as MetroWindow);
                    win.ShowMessageAsync("Nous sommes désolé", "La catégorie que vous avez demandé ne contient aucun film :(");

                    Switch(new CategorieView(), false);
                }
            }
        }

        public void Switch(UserControl uc, bool sidebar = true) => ControlSwitcher.Switch(uc, sidebar);
    }
}
