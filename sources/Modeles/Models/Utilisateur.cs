using SQLite;

namespace Models
{
    [Table("Utilisateur")]
    public class Utilisateur
    {
        [PrimaryKey, AutoIncrement, Column("id")]
        public int Id { get; private set; }

        [Column("nom"), NotNull, MaxLength(30)]
        public string Nom { get; private set; }

        [Column("prenom"), NotNull, MaxLength(30)]
        public string Prenom { get; private set; }

        [Column("password"), NotNull, MaxLength(20)]
        public string Password { get; private set; }

        [Column("isAdmin")]
        public bool IsAdmin { get; private set; }

        [Ignore]
        public bool IsLogged { get; set; }

        public Utilisateur(string nom, string prenom, string mdp)
        {
            Nom = nom;
            Prenom = prenom;
            Password = mdp;
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
