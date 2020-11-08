using ATM_Interface.Tools.MVVM;
using System;
using System.Collections.Generic;
using System.Text;

namespace ATM_Interface.ViewModel
{
    class EnterCardNumberViewModel : BaseViewModel
    {
        private String _cardNumber;
        private bool _cardDisplay;
        private List<String> _lastCombinations;

        public string CardNumber {
            get { return _cardNumber; }
            set
            {
                _cardNumber = value;
                OnPropertyChanged();
            }
        }

        public bool CardDisplay 
        { 
            get => _cardDisplay;
            set { _cardDisplay = value; }
        }

        public void KeyPadClick(string keyCode)
        {
            

            if (keyCode[0] == 'N')
            {
                CardNumber += keyCode[1];
            }
            else if(keyCode == "ERASE")
            {
                CardNumber = String.IsNullOrEmpty(CardNumber) ? "" : CardNumber.Substring(0, CardNumber.Length - 1);
                
            }


            if (String.IsNullOrEmpty(CardNumber))
            {
                CardDisplay = false;
            }
            else
            {
                CardDisplay = true;
            }
        }
    }
}
