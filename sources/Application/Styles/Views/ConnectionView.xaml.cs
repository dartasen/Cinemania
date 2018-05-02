using Interfaces;
using Managers;
using Models;
using System.Windows;
using System.Windows.Controls;
using MahApps.Metro.Controls.Dialogs;
using MahApps.Metro.Controls;

namespace Views
{
    public partial class ConnectionView : UserControl, ISwitch
    {

        public ConnectionView()
        {
            InitializeComponent();
            DataContext = this;
        }

        public void Login_Click(object sender, RoutedEventArgs args)
        {
            string pseudo = Pseudo.Text, mdp = MotDePasse.Password;

            if (string.IsNullOrWhiteSpace(pseudo) || string.IsNullOrWhiteSpace(mdp))
                return;

            var win = (Application.Current.MainWindow as MetroWindow);

            if (StockageBDD.CheckUser(pseudo, mdp)) {
                Switch(new MenuView());
                win.ShowMessageAsync("Authentification réussie", "Ouiiiiiiiiiiii !");
            } else {
                MotDePasse.Password = "";
                win.ShowMessageAsync("Erreur lors de l'authentification", "Mot de passe incorrect :(");
            }
        }

        public void Switch(UserControl uc) => PageSwitcher.Switch(uc);
    }
}
