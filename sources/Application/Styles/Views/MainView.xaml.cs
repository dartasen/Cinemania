using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Controls;
using MahApps.Metro.Controls;
using Managers;
using Models;

namespace Views
{
    public partial class MainView : MetroWindow, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<Film> ListeFilms { get; private set; }
        public Control UC_Sidebar { get; private set; } = new ConnectionView();
        public Control UC_Main { get; private set; } = new FilmView();
        public static Utilisateur CurrentUser { get; set; }

        public MainView()
        {
            InitializeComponent();

            ControlSwitcher.Main = this;
            DataContext = this;
            StockageBDD.Init();

            //TODO : Insertion à virer après les tests
            StockageBDD.Insert<Utilisateur>(new Utilisateur("test", "MF", "S", "test"));
            StockageBDD.Insert<Utilisateur>(new Utilisateur("admin", "ad", "min", "admin", true));
            StockageBDD.Insert<Film>(new Film("Perdu dans l'espace", "b", System.DateTime.Now));
            StockageBDD.Insert<Film>(new Film("Bien le bonjour", "blb", System.DateTime.Now));
            //

            ListeFilms = StockageBDD.GetFilms();
        }

        public void Navigate(UserControl nextPage, bool sidebar = true)
        {
            if (sidebar)
            {
                this.UC_Sidebar = nextPage;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(UC_Sidebar)));
            }
            else
            {
                this.UC_Main = nextPage;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(UC_Main)));
            }
        }
    }
}
