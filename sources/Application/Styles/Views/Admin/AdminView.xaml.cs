using Models.Interfaces;
using Models;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

namespace Views
{
    public partial class AdminView : UserControl, ISwitch, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public Control UC_Admin { get; private set; }
 
        /// <summary>
        /// La combobox de la vue nous renvoie un index sur cette propriété
        /// en fonction de l'index une page est affichée
        /// </summary>
        private int _selectedAction;
        public int SelectedAction
        {
            get => _selectedAction;

            set {
                _selectedAction = value;

                switch (value)
                {
                    case 1:
                        UC_Admin = new FilmManagerView();
                        break;

                    case 2:
                        UC_Admin = new UserManagerView();
                        break;
                    
                    default:
                        break;
                }

                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(UC_Admin)));
            }
        }

        public AdminView()
        {
            InitializeComponent();
            DataContext = this;
        }

        /// <summary>
        /// Fonction appellée quand on clique sur le bouton retour
        /// </summary>
        private void Return_Button_Click(object sender, RoutedEventArgs e)
        {
            Switch(new FilmView(), false);
        }

        public void Switch(UserControl uc, bool sidebar = true) => ControlSwitcher.Switch(uc, sidebar);
    }
}
