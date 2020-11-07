
using ATM_Interface.ViewModel;
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
    /// Логика взаимодействия для EnterCardNumberScreen.xaml
    /// </summary>
    public partial class EnterCardNumberScreen : UserControl, INavigatable
    {
        private EnterCardNumberViewModel _viewModel;
        public EnterCardNumberScreen()
        {
            _viewModel = new EnterCardNumberViewModel();
            DataContext = _viewModel;
            InitializeComponent();
        }

        public void KeyPadClick(string keyCode)
        {
            _viewModel.KeyPadClick(keyCode);
        }
    }
}
