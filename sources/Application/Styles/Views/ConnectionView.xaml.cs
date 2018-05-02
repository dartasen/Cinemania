using Interfaces;
using managers;
using Models;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

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

            bool connect = StockageBDD.CheckUser(pseudo, mdp);

            if (connect)
            {
                Switch(new MenuView());
            }
            else
            {
                MotDePasse.Password = "";
                MessageBox.Show("Mot de passe incorrect :(", "Erreur lors de l'authentification");
            }
        }

        public void Switch(UserControl uc)
        {
            PageSwitcher.Switch(uc);
        }
    }
}
