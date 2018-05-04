using Interfaces;
using Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Views
{
    public partial class FilmView : UserControl, ISwitch
    {
        public ObservableCollection<Film> Films
        {
            get { return (ObservableCollection<Film>) GetValue(FilmsProperty); }
            set { SetValue(FilmsProperty, value); }
        }

        public static readonly DependencyProperty FilmsProperty =
            DependencyProperty.Register("Films", typeof(ObservableCollection<Film>), typeof(FilmView), null);

        public FilmView()
        {
            InitializeComponent();
        }

        public void Switch(UserControl uc) => ControlSwitcher.Switch(uc);
    }
}
