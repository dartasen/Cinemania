namespace Models
{ 
    /// <summary>
    /// Nous permet de définir ce que notre attribut contient en propriété
    /// </summary>
    public class CategorieAttr : EnumAttr
    {
        public CategorieAttr(string img) => Img = img;

        public string Img { get; }
    }

    public enum Categorie
    {
        [CategorieAttr("pack://application:,,,/Resources/Categorie/thriller-genre.jpg")]
        THRILL,
        [CategorieAttr("pack://application:,,,/Resources/Categorie/adventure-genre.jpg")]
        AVENTURE,
        [CategorieAttr("pack://application:,,,/Resources/Categorie/action-genre.jpg")]
        ACTION,
        [CategorieAttr("pack://application:,,,/Resources/Categorie/animated-genre.jpg")]
        ANIMATION,
        [CategorieAttr("pack://application:,,,/Resources/Categorie/horror-genre.jpg")]
        HORREUR,
        [CategorieAttr("pack://application:,,,/Resources/Categorie/detective-genre.jpg")]
        POLICIER,
        [CategorieAttr("pack://application:,,,/Resources/Categorie/fantasy-genre.jpg")]
        FANTAISIE,
        [CategorieAttr("pack://application:,,,/Resources/Categorie/romance-genre.jpg")]
        ROMANTIQUE,
        [CategorieAttr("pack://application:,,,/Resources/Categorie/drama-genre.jpg")]
        COMEDIE,
        [CategorieAttr("pack://application:,,,/Resources/Categorie/war-genre.jpg")]
        GUERRE,
        [CategorieAttr("pack://application:,,,/Resources/Categorie/scifi-genre.jpg")]
        SCIENCEFICTION,

        DEFAUT
    }
}
