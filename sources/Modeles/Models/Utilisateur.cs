namespace Models
{
    public class Utilisateur
    {
        public static int Id = 0;
        public string Nom { get; }
        public string Prenom { get; }
        public string Password { get; }
        public bool IsAdmin { get; }
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
