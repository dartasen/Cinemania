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

        public Utilisateur CurrentUser { get; private set; }
        public Control UC { get; private set; }

        public MainView()
        {
            InitializeComponent();
            DataContext = this;
            StockageBDD.Init();

            PageSwitcher.pageSwitcher = this;

            UC = new ConnectionView();

            CurrentUser = new Utilisateur("test", "MF", "S", "12345");

            StockageBDD.Insert<Utilisateur>(CurrentUser);
        }

        public void Navigate(UserControl nextPage)
        {
             this.UC = nextPage;
  
             PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(UC)));
        }
    }
}
