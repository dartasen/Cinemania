using Models.Interfaces;
using Managers;
using Models;
using System.Collections.ObjectModel;
using System.Windows.Controls;

namespace Views
{
    public partial class UserManagerView : UserControl, ISwitch
    {
        /// <summary>
        /// Liste des utilisateurs à afficher
        /// </summary>
        public Collection<Utilisateur> Users { get; } = StockageBDD.GetUsers();

        public dynamic Selected { get; set; }

        public UserManagerView()
        {
            InitializeComponent();
            DataContext = this;
        }

        public void Switch(UserControl uc, bool sidebar = true) => ControlSwitcher.Switch(uc, sidebar);
    }
}
