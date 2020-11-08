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

        private RelayCommand<object> _bottomKeypadCommand;
        private RelayCommand<object> _sidesKeypadCommand;

        private String _cardDisplayVisibility = "Hidden";
        private bool _cardDisplay = false;

        public StartScreenViewModel()
        {
            NavigationManager.Instance.Initialize(new InitializationNavigationModel(this));
            NavigationManager.Instance.Navigate(ViewType.EnterCardNumber);
        }

        public RelayCommand<Object> BottomKeyPadCommand
        {
            get
            {
                return _bottomKeypadCommand ?? (_bottomKeypadCommand = new RelayCommand<object>(BottomKeyPadClick,
                    o => true));
            }
        }

        public RelayCommand<Object> SidesKeyPadCommand
        {
            get
            {
                return _sidesKeypadCommand ?? (_sidesKeypadCommand = new RelayCommand<object>(SidesKeyPadClick,
                    o => true));
            }
        }

        public bool CardDisplay
        {
            get => _cardDisplay;
            set => _cardDisplay = value;
        }

        public string CardDisplayVisibility 
        { 
            get => _cardDisplayVisibility;
            set
            {
                _cardDisplayVisibility = value;
                OnPropertyChanged();
            }
        }


        private void BottomKeyPadClick(object o)
        {
            _screenContent.KeyPadClick(o.ToString());

            if(_screenContent.CardDisplay() != CardDisplay)  //card display change state
            {
                CardDisplay = !CardDisplay;
                CardDisplayVisibility = CardDisplay ? "Visible" : "Hidden";
            }
        }

        private void SidesKeyPadClick(object o)
        {
            _screenContent.KeyPadClick(o.ToString());
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
