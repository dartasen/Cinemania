using SQLite;

namespace Models
{
    [Table("Utilisateur")]
    public class Utilisateur
    {
        [Column("id"), PrimaryKey, AutoIncrement]
        public int Id { get; private set; }

        [Column("pseudo"), NotNull, MaxLength(30)]
        public string Pseudo { get; private set; }

        [Column("nom"), NotNull, MaxLength(30)]
        public string Nom { get; private set; }

        [Column("prenom"), NotNull, MaxLength(30)]
        public string Prenom { get; private set; }

        [Column("password"), NotNull, MaxLength(20)]
        public string Password { get; private set; }

        [Column("isAdmin")]
        public bool IsAdmin { get; private set; }

        [Column("isLogged")]
        public bool IsLogged { get; set; }

        public Utilisateur(string pseudo, string nom, string prenom, string mdp)
        {
            Pseudo = pseudo;
            Nom = nom;
            Prenom = prenom;
            Password = mdp;
            IsAdmin = false;
            IsLogged = false;
        }

        public Utilisateur()
        {
            Pseudo = "test";
            Nom = "Défaut";
            Prenom = "Défaut";
            Password = "test";
            IsAdmin = true;
            IsLogged = true;
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
