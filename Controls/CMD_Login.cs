using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Controls
{
    class CMD_Login : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public EventHandler ExecuteChanged()
        {
            return CanExecuteChanged;
        }

        public bool CanExecute(object param)
        {
            return true;
        }

        public void Execute(object param)
        {
            MessageBox.Show("On se le demande ?", "Ou est mon binôme");
        }
    }
}
