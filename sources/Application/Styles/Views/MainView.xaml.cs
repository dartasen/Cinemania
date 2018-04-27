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
        public Utilisateur MFS { get; }
        public Control UC { get; set; }
        private StockageBDD sql;

        public event PropertyChangedEventHandler PropertyChanged;

        public MainView()
        {
            InitializeComponent();
            DataContext = this;

            PageSwitcher.pageSwitcher = this;

            UC = new ConnectionView();

            MFS = new Utilisateur("MF", "S", "12345");
            sql = new StockageBDD();
        }

        public void Navigate(UserControl nextPage)
        {
                this.UC = nextPage;
                RaisePropertyChanged("UC");
        }

        private void RaisePropertyChanged(String property)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(property));
        }
    }
}
