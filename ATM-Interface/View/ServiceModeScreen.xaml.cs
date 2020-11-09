using ATM_Interface.Tools.Navigation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ATM_Interface.View
{
    /// <summary>
    /// Логика взаимодействия для ServiceModeScreen.xaml
    /// </summary>
    public partial class ServiceModeScreen : UserControl, INavigatable
    {
        public ServiceModeScreen()
        {
            InitializeComponent();
        }

        public bool CardDisplay()
        {
            throw new NotImplementedException();
        }

        public void KeyPadClick(string keyCode)
        {
            //throw new NotImplementedException();
        }

        public bool ServiceMode()
        {
            return true;
            //throw new NotImplementedException();
        }
    }
}
