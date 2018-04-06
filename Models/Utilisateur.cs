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

        public Utilisateur(string nom, string prenom, string mdp)
        {
            this.nom = nom;
            this.prenom = prenom;
            this.mdp = mdp;
        }

        public override string ToString()
        {
            return $"{nom} {prenom}";
        }
    }
}
