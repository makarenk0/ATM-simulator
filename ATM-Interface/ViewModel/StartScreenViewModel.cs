using ATM_Interface.Tools.Managers;
using ATM_Interface.Tools.MVVM;
using ATM_Interface.Tools.Navigation;
using System;
using System.Collections.Generic;
using System.Text;

namespace ATM_Interface.ViewModel
{
    class StartScreenViewModel : BaseViewModel, IContentOwner
    {

        private INavigatable _screenContent;

        public StartScreenViewModel()
        {
            NavigationManager.Instance.Initialize(new InitializationNavigationModel(this));
            NavigationManager.Instance.Navigate(ViewType.EnterCardNumber);
        }

        public INavigatable Content 
        {
            get { return _screenContent; }
            set
            {
                _screenContent = value;
                OnPropertyChanged();
            }
        }
    }
}
