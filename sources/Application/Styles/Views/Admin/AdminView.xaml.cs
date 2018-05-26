using Interfaces;
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

        private void Return_Button_Click(object sender, RoutedEventArgs e)
        {
            Switch(new FilmView(), false);
        }

        public void Switch(UserControl uc, bool sidebar = true) => ControlSwitcher.Switch(uc, sidebar);
    }
}
