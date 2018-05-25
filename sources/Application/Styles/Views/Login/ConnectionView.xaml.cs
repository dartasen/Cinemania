using Interfaces;
using Managers;
using Models;
using System.Windows;
using System.Windows.Controls;
using MahApps.Metro.Controls.Dialogs;
using MahApps.Metro.Controls;
using Styles.Views;
using Models.Events;

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
        public void Login_Click(object sender, RoutedEventArgs args)
        {
            var win = (Application.Current.MainWindow as MetroWindow);
            string pseudo = Pseudo.Text, mdp = MotDePasse.Password;

            if (string.IsNullOrWhiteSpace(pseudo) || string.IsNullOrWhiteSpace(mdp))
            {
                win.ShowMessageAsync("Erreur lors de l'authentification", "Merci de renseigner toutes les informations :@");
                return;
            }

            var user = StockageBDD.CheckUser(pseudo, mdp);

            if (user != null)
            {
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
        public void Register_Click(object sender, RoutedEventArgs args)
        {
            ControlSwitcher.Switch(new RegistrationView(), false);
        }

        public void Switch(UserControl uc, bool sidebar = true) => ControlSwitcher.Switch(uc, sidebar);
    }
}
