using Interfaces;
using Managers;
using Models;
using System.Collections.ObjectModel;
using System.Windows.Controls;

namespace Views
{
    public partial class UserManagerView : UserControl, ISwitch
    {
        public Collection<Utilisateur> Users { get; }

        public UserManagerView()
        {
            InitializeComponent();
            DataContext = this;
        }

        public void Switch(UserControl uc, bool sidebar = true) => ControlSwitcher.Switch(uc, sidebar);
    }
}
