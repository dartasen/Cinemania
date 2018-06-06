﻿using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Models.Converter
{
    public class StringToFilmImageConverter : IValueConverter
    {
        /// <summary>
        /// Chemin par défaut jusqu'au dossier des ressources
        /// </summary>
        private const string path = "pack://application:,,,/Resources/Film/Image/";

        /// <summary>
        /// Le converteur est censé rencevoir l'ID du <see cref="Film"/>
        /// </summary>
        /// <returns>Renvoie le chemin absolue de l'image du film</returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return String.Format(path + "{0}.jpg", value as int?);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return "";
        }
    }
}
