using Models.Interfaces;
using Managers;
using Models;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Windows;

namespace Views
{
    public partial class UserManagerView : UserControl, ISwitch
    {
        public Collection<Utilisateur> Users { get; } = StockageBDD.GetUsers();

        private dynamic _selected;
        public dynamic Selected { get => _selected; set { _selected = value; MessageBox.Show("e" + _selected); } }

        public UserManagerView()
        {
            InitializeComponent();
            DataContext = this;
        }

        public void Switch(UserControl uc, bool sidebar = true) => ControlSwitcher.Switch(uc, sidebar);
    }
}
