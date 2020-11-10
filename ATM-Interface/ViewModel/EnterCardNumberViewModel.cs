using ATM_Interface.Tools.MVVM;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using ATM_Interface.Models;
using ATM_Interface.Tools.Managers;
using ATM_Interface.Tools.Navigation;

namespace ATM_Interface.ViewModel
{
    class EnterCardNumberViewModel : BaseViewModel
    {
        private String _cardNumber = "";
        private String _cardError = "";
        private bool _cardDisplay;
        private List<String> _lastCombinations;

        public EnterCardNumberViewModel()
        {
           
        }

        public void Init()
        {
            _lastCombinations = new List<string>();
            CardNumber = "";
        }

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

        public string CardError 
        { 
            get => _cardError;
            set
            {
                _cardError = value;
                OnPropertyChanged();
            }
        }

        public void KeyPadClick(string keyCode)
        {
           

            if (keyCode[0] == 'N' && CardNumber.Length < 16)
            {
                CardNumber += keyCode[1];
                CardError = "";
            }
            else if(keyCode == "ERASE")
            {
                CardNumber = String.IsNullOrEmpty(CardNumber) ? "" : CardNumber.Substring(0, CardNumber.Length - 1);
                CardError = "";
            }
            else if(keyCode == "ENTER")
            {
                if(CardNumber.Length != 16)
                {
                    CardError = "Card number is not full!";
                }
                else
                {
                    String res = ProcessorModel.Processor.handleInput(CardNumber);
                    if (res == "true")
                    {
                        NavigationManager.Instance.Navigate(ViewType.PinInputMode);
                    }
                    else if(res == "blocked")
                    {
                        CardError = "Card is blocked!";
                    }
                    else
                    {
                        CardError = "Card doesn't exist!";
                    }
                }
            }



            AddLastCombination(keyCode);
            if (String.IsNullOrEmpty(CardNumber))
            {
                CardDisplay = false;
            }
            else
            {
                CardDisplay = true;
            }
        }

        private void AddLastCombination(string comb)
        {
            if(_lastCombinations.Count == 8)
            {
                _lastCombinations.RemoveAt(0);
            }
            _lastCombinations.Add(comb);

            if(_lastCombinations.SequenceEqual(new List<string>() {"L1", "L3", "R2", "R4", "N1", "N2", "N3", "N4"}))
            {
                CardNumber = "";
                NavigationManager.Instance.Navigate(ViewType.ServiceMode);
            }
        }
    }
}
