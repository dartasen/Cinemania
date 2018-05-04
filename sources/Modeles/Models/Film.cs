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

        public Film(string titre, string realisateur, DateTime sortie)
        {
            Titre = titre;
            Realisateur = realisateur;
            Sortie = sortie;
        }

        public Film() { }
    }
}
