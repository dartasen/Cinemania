using System.Data.SQLite.Linq;
using System.Linq;

namespace Models
{
    public class Utilisateur
    {
        public static int Id = 0;
        public string Nom { get; private set; }
        public string Prenom { get; private set; }
        public string Password { get; private set; }
        public bool IsAdmin { get; private set; }
        public bool IsLogged { get; set; }

        public Utilisateur(string nom, string prenom, string mdp)
        {
            Nom = nom;
            Prenom = prenom;
            Password = mdp;
            Id++;
        }

        public void Login()
        {
            IsLogged = true;
        }

        public void Logout()
        {
            IsLogged = false;
        }

        public override string ToString()
        {
            return $"{Nom} {Prenom}";
        }
    }
}
