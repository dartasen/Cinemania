using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Controls
{
    public partial class UCConnexion : UserControl
    {
        public ICommand cmd { get; set; }
        public new Window Parent { get; set; }

        public UCConnexion()
        {
            InitializeComponent();
            DataContext = this;

            cmd = new CMD_Login();
        }
    }
}
