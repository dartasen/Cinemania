using Managers;
using Models;
using System.Windows;
using System.Windows.Controls;
using MahApps.Metro.Controls.Dialogs;
using MahApps.Metro.Controls;
using Styles.Views;
using Models.Event;
using Models.Interfaces;

namespace Views
{
    public partial class ConnectionView : UserControl, ISwitch
    {

        public ConnectionView()
        {
            InitializeComponent();
            DataContext = this;
        }

        /// <summary>
        /// Méthode appelée quand on clique sur le bouton Se connecter
        /// </summary>
        private void Login_Click(object sender, RoutedEventArgs e)
        {
            var win = (Application.Current.MainWindow as MetroWindow);
            string pseudo = Pseudo.Text, mdp = MotDePasse.Password;

            if (string.IsNullOrWhiteSpace(pseudo) || string.IsNullOrWhiteSpace(mdp))
            {
                win.ShowMessageAsync("Erreur lors de l'authentification", "Merci de renseigner toutes les informations :@");
                return;
            }

            // Retourne l'utilisateur contenue dans la BDD, null sinon
            var user = StockageBDD.CheckUser(pseudo, mdp);

            if (user != null)
            {
                user.Login();

                UserChangedEvent.Instance.User = user;
                win.ShowMessageAsync("Authentification réussie", "Ouiiiiiiiiiiii !");
            }
            else
            {
                MotDePasse.Clear();
                win.ShowMessageAsync("Erreur lors de l'authentification", "Mot de passe incorrect :(");
            }
        }

        /// <summary>
        /// Méthode appelée quand on clique sur le bouton inscription
        /// </summary>
        private void Register_Click(object sender, RoutedEventArgs e)
        {
            ControlSwitcher.Switch(new RegistrationView(), false);
        }

        public void Switch(UserControl uc, bool sidebar = true) => ControlSwitcher.Switch(uc, sidebar);
    }
}
