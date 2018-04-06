using Controls;
using Models;
using System;
using System.Collections.Generic;
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

namespace Styles
{
    public partial class MainWindow : Window
    {
        public Utilisateur MFS { get; }

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;

            MFS = new Utilisateur("MF", "S", "12345");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Content = new Login();
        }
        
    }
}
