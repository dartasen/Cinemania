using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public struct Film
    {
        public static int Id = 0;
        public string Titre { get; private set; }
        public string Realisateur { get; private set; }
        public DateTime Sortie { get; private set; }

        public Film(string titre, string realisateur, DateTime sortie)
        {
            Titre = titre;
            Realisateur = realisateur;
            Sortie = sortie;
            Id++;
        }
    }
}
