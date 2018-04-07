using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Utilisateur
    {
        public string nom { get; }
        public string prenom { get; }
        public string mdp { get; }
        public bool isAdmin { get; }
        public bool isLogged { get; set; }

        public Utilisateur(string nom, string prenom, string mdp)
        {
            this.nom = nom;
            this.prenom = prenom;
            this.mdp = mdp;
        }

        public void login()
        {
            isLogged = true;
        }

        public void logout()
        {
            isLogged = false;
        }

        public override string ToString()
        {
            return $"{nom} {prenom}";
        }
    }
}
