using System;
using System.Windows;
using System.Windows.Controls;
using Controls;
using Interfaces;
using MahApps.Metro.Controls;
using managers;
using Models;

namespace Styles
{
    public partial class MainWindow : MetroWindow
    {
        public Utilisateur MFS { get; }
        public Control UC { get; set; }
        private StockageBDD sql;

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;

            UC = new UCConnexion();
            (UC as UCConnexion).Parent = this;

            MFS = new Utilisateur("MF", "S", "12345");
            sql = null;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            UC = new UCMenu();
        }

        public void Navigate(UserControl nextPage)
        {
            this.Content = nextPage;
        }

        public void Navigate(UserControl nextPage, object state)
        {
            this.Content = nextPage;
            ISwitch s = nextPage as ISwitch;

            if (s != null)
                s.UtilizeState(state);
            else
                throw new ArgumentException("NextPage is not ISwitchable! "+ nextPage.Name.ToString());
        }

    }
}
