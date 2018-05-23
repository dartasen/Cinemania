using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Events
{
    public sealed class UserChangedEvent
    {
        public static UserChangedEvent Instance { get; } = new UserChangedEvent();
        public event EventHandler<UserChangedEventArgs> UserChanged;

        private Utilisateur user;
        public Utilisateur User
        {
            get => user;

            set
            {
                if (value == user)
                {
                    return;
                }

                user = value;
                OnUserChanged(new UserChangedEventArgs(value));
            }
        }

        private UserChangedEvent() { }

        private void OnUserChanged(UserChangedEventArgs args)
        {
            UserChanged?.Invoke(this, args);
        }
    }
}
