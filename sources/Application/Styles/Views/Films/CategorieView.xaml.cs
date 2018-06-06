using Models;
using Models.Interfaces;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Views
{
    public partial class CategorieView : UserControl, ISwitch
    {
        /// <summary>
        /// La listView nous renvoie la catégorie sélectionné ici
        /// </summary>
        private dynamic _selectedCategorie;
        public dynamic SelectedCategorie
        {
            get => _selectedCategorie;

            set
            {
                _selectedCategorie = value;

                Categorie cat = Categorie.DEFAUT;

                try
                {
                    if (_selectedCategorie != null)
                    {
                        dynamic test = _selectedCategorie;
                        cat = test.Categorie;
                    }
                } catch (Exception)
                {
                    cat = Categorie.DEFAUT;
                }

                Switch(new FilmView(cat), false);
            }
        }

        public CategorieView()
        {
            InitializeComponent();
            DataContext = this;

            //On instancie la listview en utilisant une classe anonyme pour pouvoir ajouter l'image venant de l'attribut de la catégorie
            foreach (Categorie cat in Enum.GetValues(typeof(Categorie)).Cast<Categorie>())
            {
                if (cat.Equals(Categorie.DEFAUT))
                    continue;

                CategorieListView.Items.Add(new
                {
                    Categorie = cat,
                    Nom = cat.ToString(),
                    Img = (cat.GetAttr() as CategorieAttr).Img
                });
            }
        }

        public void Switch(UserControl uc, bool sidebar = true) => ControlSwitcher.Switch(uc, sidebar);
    }
}
