﻿using ATM_Interface.Tools.Navigation;
using ATM_Interface.ViewModel;
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
        private ServiceScreenViewModel _viewModel;
        public ServiceModeScreen()
        {

            _viewModel = new ServiceScreenViewModel();
            DataContext = _viewModel;
            InitializeComponent();
        }

        public bool CardDisplay()
        {
            return false;
        }

        public void KeyPadClick(string keyCode)
        {
            _viewModel.KeyPadClick(keyCode);
        }

        public void Init(String arg = "")
        {
            _viewModel.Init();
        }
    }
}
