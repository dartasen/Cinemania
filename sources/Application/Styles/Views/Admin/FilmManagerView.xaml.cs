using Interfaces;
using Managers;
using Models;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace Views
{
    public partial class FilmManagerView : UserControl, ISwitch
    {
        public ObservableCollection<Film> Films { get; private set; }

        public FilmManagerView()
        {
            InitializeComponent();
            DataContext = this;

            Films = StockageBDD.GetFilms();
        }

        public void Switch(UserControl uc, bool sidebar = true) => ControlSwitcher.Switch(uc, sidebar);
    }
}
