using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models;
using Views;

namespace Stockage.Managers.Test
{
    [TestClass]
    public class AppTest
    {
        [TestMethod, ExpectedException(typeof(Exception))]
        public void SwitchViewFailed() => ControlSwitcher.Switch(new ConnectionView());

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void SwitchUserControlFailed() => ControlSwitcher.Switch(null);
    }
}
