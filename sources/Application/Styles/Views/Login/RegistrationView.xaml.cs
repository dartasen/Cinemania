﻿using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using Managers;
using Models;
using Models.Event;
using Models.Interfaces;
using System.Windows;
using System.Windows.Controls;
using Views;

namespace Styles.Views
{
    public partial class RegistrationView : UserControl, ISwitch
    {

        public RegistrationView()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Méthode appelée quand on clique sur le bouton inscription
        /// </summary>
        private void Registration_Click(object sender, RoutedEventArgs e)
        {
            string pseudo = Pseudo.Text, nom = Nom.Text, prenom = Prenom.Text, mdp = MotDePasse.Password;
            var win = (Application.Current.MainWindow as MetroWindow);

            if (string.IsNullOrEmpty(pseudo) || string.IsNullOrEmpty(nom) || string.IsNullOrEmpty(prenom) || string.IsNullOrEmpty(mdp))
            {
                win.ShowMessageAsync("Erreur lors de l'inscription", "Merci de renseigner tout les champs :@");
                MotDePasse.Clear();

                return;
            }

            if (mdp.Length < 3)
            {
                win.ShowMessageAsync("Erreur lors de l'inscription", "Votre mot de passe doit faire plus de 3 caractères :(");
                return;
            }

            if (StockageBDD.CheckIfUserExists(pseudo))
            {
                win.ShowMessageAsync("Erreur lors de l'inscription", "Un utilisateur avec ce pseudo existe déjà");

                MotDePasse.Clear();
                Pseudo.Clear();

                return;
            }

            Utilisateur user = new Utilisateur(pseudo, nom, prenom, mdp);

            int insert = StockageBDD.Insert<Utilisateur>(user);

            if (insert < 0)
            {
                win.ShowMessageAsync("Erreur critique", "Impossible de vous inscrire, merci de contacter un administrateur");
                return;
            }

            UserChangedEvent.Instance.User = user;
            Switch(new FilmView(), false);
        }

        /// <summary>
        /// Méthode appelée quand on clique sur le bouton annuler
        /// </summary>
        private void Back_Click(object sender, RoutedEventArgs e)
        {
            Switch(new FilmView(), false);
        }

        public void Switch(UserControl uc, bool sidebar = true) => ControlSwitcher.Switch(uc, sidebar);
    }
}
