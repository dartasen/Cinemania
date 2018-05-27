using System;

namespace Models.Event
{
    public sealed class UserChangedEvent
    {
        public static UserChangedEvent Instance { get; } = new UserChangedEvent();
        public event EventHandler<UserChangedEventArgs> UserChanged;

        /// <summary>
        /// On stockage le paramètre newUSer de notre classe <see cref="UserChangedEventArgs"/>
        /// </summary>
        private Utilisateur user;
        public Utilisateur User
        {
            get => user;

            set
            {
                if (value == user || value == null)
                {
                    return;
                }

                user = value;
                OnUserChanged(new UserChangedEventArgs(value));
            }
        }

        /// <summary>
        /// On empêche la classe d'être instancié en mettant private le constructeur
        /// </summary>
        private UserChangedEvent() { }

        /// <summary>
        /// Méthode du patterne standart des évents pour propager l'évenement
        /// </summary>
        /// 
        /// <param name="args"></param>
        private void OnUserChanged(UserChangedEventArgs args)
        {
            UserChanged?.Invoke(this, args);
        }
    }
}
