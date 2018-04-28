using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using Interfaces;
using MahApps.Metro.Controls;
using managers;
using Models;

namespace Views
{
    public partial class MainView : MetroWindow, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public Utilisateur CurrentUser { get; private set; }
        public Control UC { get; private set; }
        private StockageBDD Sql { get; set; }

        public MainView()
        {
            InitializeComponent();
            DataContext = this;

            PageSwitcher.pageSwitcher = this;

            UC = new MenuView();

            CurrentUser = new Utilisateur("MF", "S", "12345");
            Sql = new StockageBDD();

            Sql.Database.Insert(CurrentUser);
        }

        public void Navigate(UserControl nextPage)
        {
             this.UC = nextPage;

             if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs("UC"));
        }
    }
}
