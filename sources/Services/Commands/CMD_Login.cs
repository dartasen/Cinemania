using System;
using System.Windows;
using System.Windows.Input;

namespace Controls
{
    public class CMD_Login : ICommand
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
