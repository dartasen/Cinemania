using SQLite;

namespace Models
{
    [Table("Categorie")]
    public class Categorie
    {
        [Column("id"), PrimaryKey, AutoIncrement]
        public int Id { get; private set; }

        [Column("nom"), NotNull, MaxLength(30)]
        public string Nom { get; private set; }

        public Categorie(string nom)
        {
            Nom = nom;
        }

        public Categorie()
        {
            Nom = "ERROR";
        }
    }
}
