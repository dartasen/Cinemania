using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using MahApps.Metro.Controls;
using Managers;
using Models;
using Models.Events;

namespace Views
{
    public partial class MainView : MetroWindow, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public Control UC_Sidebar { get; private set; } = new ConnectionView();
        public static Utilisateur CurrentUser { get; set; }
        public Control UC_Main { get; private set; }


        public MainView()
        {
            InitializeComponent();

            StockageBDD.Init();
            StockageBDD.ServiceInit();

            UC_Main = new FilmView();

            ControlSwitcher.Main = this;
            DataContext = this;

            UserChangedEvent.Instance.UserChanged += OnUserChanged;
        }

        /// <summary>
        /// Méthode réceptive de l'évenement <see cref="UserChangedEvent"/>
        /// </summary>
        /// 
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnUserChanged(object sender, UserChangedEventArgs e)
        {
            CurrentUser = e.NewUser;
            Navigate(new MenuView());
        }

        /// <summary>
        /// Méthode qui est appellé dans <see cref="ControlSwitcher"/> qui permet de naviguer entre les vues
        /// </summary>
        /// 
        /// <param name="nextPage">Le UserControl à afficher</param>
        /// <param name="sidebar">Booléen qui permet de cibler la sidebar ou l'écran principal</param>
        public void Navigate(UserControl nextPage, bool sidebar = true)
        {
            if (nextPage == null)
                throw new ArgumentNullException("Le UserControl ne peut-être nul pour la navigation");

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
