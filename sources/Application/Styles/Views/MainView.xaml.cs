using System.Collections.ObjectModel;
using System.ComponentModel;
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
        public Utilisateur CurrentUser { get; private set; }
        public Control UC { get; private set; } = new ConnectionView();

        public MainView()
        {
            InitializeComponent();

            ControlSwitcher.main = this;
            DataContext = this;
            StockageBDD.Init();

            CurrentUser = new Utilisateur("test", "MF", "S", "12345");
            ListeFilms = StockageBDD.GetFilms();

            StockageBDD.Insert<Utilisateur>(CurrentUser);
        }

        public void Navigate(UserControl nextPage)
        {
            this.UC = nextPage;

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(UC)));
        }
    }
}
