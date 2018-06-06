using System;
using System.Globalization;
using System.IO;
using System.Windows;
using System.Windows.Data;

namespace Models.Converter
{
    public class IdToFilmSynopsisConverter : IValueConverter
    {
        /// <summary>
        /// Chemin par défaut jusqu'au dossier des ressources
        /// </summary>
        private const string path = "pack://application:,,,/Resources/Film/Synopsis/";

        /// <summary>
        /// Le converteur est censé rencevoir l'ID du <see cref="Film"/>
        /// </summary>
        /// <returns>Renvoie le chemin absolue de l'image du film</returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string synopsis = String.Format(path + "{0}.txt", value as int?);

            if (!File.Exists(synopsis))
                return "ERROR";

            using (StreamReader film = File.OpenText(path))
            {
                return film.ReadToEnd();
            } 
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return "";
        }
    }
}
