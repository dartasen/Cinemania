using System;
using SQLite;

namespace Models
{
    [Table("Film")]
    public class Film
    {
        [PrimaryKey, AutoIncrement, Column("id")]
        public int Id { get; private set; }

        [Column("titre"), NotNull, MaxLength(30)]
        public string Titre { get; private set; }

        [Column("realisateur"), NotNull, MaxLength(20)]
        public string Realisateur { get; private set; }

        [Column("date"), NotNull]
        public DateTime Sortie { get; private set; }

        [Column("categorie"), NotNull]
        public Categorie Categorie { get; private set; }

        public Film(string titre, string realisateur, Categorie cat, DateTime sortie)
        {
            Titre = titre;
            Realisateur = realisateur;
            this.Categorie = cat;
            Sortie = sortie;
        }

        public Film() {
            Titre = "ERROR";
            Realisateur = "ERROR";
            Sortie = DateTime.Now;
            Categorie = Categorie.DEFAUT;
        }

        public override string ToString()
        {
            return $"{Titre} par {Realisateur} : ({Categorie})";
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            if (obj is Film filmObj)
                return Id.Equals(filmObj.Id);

            return false;
        }

        public override int GetHashCode()
        {
            return 3 * Id + Titre.GetHashCode();
        }
    }
}
