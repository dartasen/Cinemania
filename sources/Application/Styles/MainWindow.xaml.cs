using System.Windows;
using System.Windows.Controls;
using Models;

namespace Styles
{
    public partial class MainWindow
    {
        public Utilisateur MFS { get; }
        public Control UC { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;

            UC = new UCConnexion();
            (UC as UCConnexion).Parent = this;

            MFS = new Utilisateur("MF", "S", "12345");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            UC = new UCMenu();
        }
        
    }
}
