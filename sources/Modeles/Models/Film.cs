using System;
using System.IO;
using SQLite;

namespace Models
{
    [Table("Film")]
    public class Film
    {
        [PrimaryKey, AutoIncrement, Column("id")]
        public int Id { get; private set; }

        [Column("Img"), NotNull]
        public int Img { get; private set; }

        [Column("titre"), NotNull, MaxLength(30)]
        public string Titre { get; private set; }

        [Column("realisateur"), NotNull, MaxLength(20)]
        public string Realisateur { get; private set; }

        [Column("date"), NotNull]
        public DateTime Sortie { get; private set; }

        [Column("categorie"), NotNull]
        public Categorie Categorie { get; private set; }

        public Film(string titre, string realisateur, Categorie cat, DateTime sortie, int img)
        {
            Titre = titre;
            Realisateur = realisateur;
            Categorie = cat;
            Sortie = sortie;
            Img = img;
        }

        public Film() { }

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
