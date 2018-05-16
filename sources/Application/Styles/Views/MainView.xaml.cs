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
        public Control UC { get; private set; } = new ConnectionView();
        public static Utilisateur CurrentUser { get; set; }

        public MainView()
        {
            InitializeComponent();

            ControlSwitcher.main = this;
            DataContext = this;
            StockageBDD.Init();

            StockageBDD.Insert<Utilisateur>(new Utilisateur("test", "MF", "S", "test"));
            StockageBDD.Insert<Utilisateur>(new Utilisateur("admin", "ad", "min", "admin", true));
            StockageBDD.Insert<Film>(new Film("Perdu dans l'espace", "b", System.DateTime.Now));
            StockageBDD.Insert<Film>(new Film("Perdu dans l'espacee", "b", System.DateTime.Now));
            StockageBDD.Insert<Film>(new Film("Perdu dans l'espacee", "b", System.DateTime.Now));
            StockageBDD.Insert<Film>(new Film("Perdu dans l'espaceeee", "b", System.DateTime.Now));

            ListeFilms = StockageBDD.GetFilms();
        }

        public void Navigate(UserControl nextPage)
        {
            this.UC = nextPage;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(UC)));
        }
    }
}
