using Models;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace Views
{
    public partial class FilmManagerView : UserControl
    {
        public ObservableCollection<Film> Films
        {
            get { return (ObservableCollection<Film>)GetValue(FilmsProperty); }
            set { SetValue(FilmsProperty, value); }
        }

        public static readonly DependencyProperty FilmsProperty =
            DependencyProperty.Register("Films", typeof(ObservableCollection<Film>), typeof(FilmManagerView), null);

        public FilmManagerView()
        {
            InitializeComponent();
        }
    }
}
