using ATM_Interface.Tools.MVVM;
using System;
using System.Collections.Generic;
using System.Text;

namespace ATM_Interface.ViewModel
{
    class EnterCardNumberViewModel : BaseViewModel
    {
        private String _cardNumber;

        public string CardNumber {
            get { return _cardNumber; }
            set
            {
                _cardNumber = value;
                OnPropertyChanged();
            }
        }

        public void KeyPadClick(string keyCode)
        {
            
            if(keyCode[0] == 'N')
            {
                CardNumber += keyCode[1];
            }
        }
    }
}
