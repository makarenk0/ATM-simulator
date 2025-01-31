﻿using ATM_Interface.ViewModel;
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
    /// Логика взаимодействия для StartScreen.xaml
    /// </summary>
    public partial class StartScreen : UserControl
    {
        private StartScreenViewModel _viewModel;
        
        public StartScreen()
        {
            _viewModel = new StartScreenViewModel();
            DataContext = _viewModel;
            InitializeComponent();
        }
    }
}
