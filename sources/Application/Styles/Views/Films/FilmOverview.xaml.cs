using Models.Interfaces;
using Models;
using System.Windows;
using System.Windows.Controls;

namespace Views
{

    public partial class FilmOverview : UserControl, ISwitch
    {
        public Film CurrentFilm
        {
            get => (Film) GetValue(CurrentFilmProperty);
            set => SetValue(CurrentFilmProperty, value);
        }

        public static readonly DependencyProperty CurrentFilmProperty =
            DependencyProperty.Register("CurrentFilm", typeof(Film), typeof(FilmOverview), null);

        public FilmOverview(Film film)
        {
            InitializeComponent();
            CurrentFilm = film;

            DataContext = CurrentFilm;
        }

        private void Return_Button_Click(object sender, RoutedEventArgs e)
        {
            Switch(new FilmView(), false);
        }

        public void Switch(UserControl uc, bool sidebar = true) => ControlSwitcher.Switch(uc, sidebar);
    }
}
