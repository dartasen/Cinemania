using Models;
using Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;

namespace Views
{
    public partial class CategorieView : UserControl, ISwitch
    {
        public List<Categorie> categories = Enum.GetValues(typeof(Categorie)).Cast<Categorie>().ToList();

        public CategorieView()
        {
            InitializeComponent();
        }

        public void Switch(UserControl uc, bool sidebar = true) => ControlSwitcher.Switch(uc, sidebar);
    }
}
