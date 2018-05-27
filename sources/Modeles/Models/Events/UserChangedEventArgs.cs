using System;

namespace Models.Event
{
    /// <summary>
    /// Classe propageant les arguments de l'évenement
    /// L'évenement se déclenchera lors du login et de l'inscription
    /// De plus il propragera l'utilisateur concerné
    /// </summary>
    /// 
    public class UserChangedEventArgs : EventArgs
    {

        /// <summary>
        /// L'utilisateur à changer
        /// </summary>
        public readonly Utilisateur NewUser;

        /// <summary>
        /// Constructeur
        /// </summary>
        /// 
        /// <param name="newUser">Nouvel utilisateur</param>
        public UserChangedEventArgs(Utilisateur newUser)
        {
            NewUser = newUser;
        }

    }
}
