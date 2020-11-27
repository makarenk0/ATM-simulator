using ATM_Interface.Models;
using ATM_Interface.Tools.Managers;
using ATM_Interface.Tools.MVVM;
using ATM_Interface.Tools.Navigation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ATM_Interface.ViewModel
{
    class TransferSumViewModel : BaseViewModel
    {
        private String _cardNumber;
        private String _cardNumberBackColor;
        private String _error;
        private String _successText;

        private string _sumsDisplay;
        private string _currentBalance;

        public string SuccessText
        {
            get => _successText;
            set
            {
                _successText = value;
                OnPropertyChanged();
            }
        }

        public string CurrentBalance
        {
            get => _currentBalance;
            set
            {
                _currentBalance = value;
                OnPropertyChanged();
            }
        }

        public string CardNumber
        {
            get { return _cardNumber; }
            set
            {
                _cardNumber = value;
                OnPropertyChanged();
            }
        }

        public string Error
        {
            get => _error;
            set
            {
                _error = value;
                OnPropertyChanged();
            }
        }

        public string SumsDisplay
        {
            get => _sumsDisplay;
            set
            {
                _sumsDisplay = value;
                OnPropertyChanged();
            }
        }

        public string CardNumberBackColor
        {
            get => _cardNumberBackColor;
            set
            {
                _cardNumberBackColor = value;
                OnPropertyChanged();
            }
        }

        public void Init()
        {
            SumsDisplay = "Hidden";
            CardNumberBackColor = "White";
            CardNumber = "";
            Error = "";
            SuccessText = "";
            CurrentBalance = ProcessorModel.Processor.handleInput("BALANCE");
        }

        public void KeyPadClick(string keyCode)
        {
            if (keyCode[0] == 'N' && CardNumber.Length < 16 && SumsDisplay == "Hidden")
            {
                CardNumber += keyCode[1];
                Error = "";
            }
            else if (keyCode == "ERASE" && CardNumber.Length > 0 && SumsDisplay == "Hidden")
            {
                CardNumber = CardNumber.Substring(0, CardNumber.Length - 1);
                Error = "";
            }
            else if (keyCode == "ENTER")
            {
                if (CardNumber.Length != 16 || ProcessorModel.Processor.handleInput(String.Concat("EXIST=", CardNumber)) != "true")
                {
                    Error = "Card number is not valid!";
                }
                else
                {
                    SumsDisplay = "Visible";
                    CardNumberBackColor = "Gray";
                }
            }
            else if (keyCode == "CANCEL" && SumsDisplay == "Visible")
            {
                SumsDisplay = "Hidden";
                CardNumberBackColor = "White";
            }
            else if (keyCode == "R3")
            {
                NavigationManager.Instance.Navigate(ViewType.CustomSumMode, CardNumber);
            }
            else if (keyCode == "R4")
            {
                NavigationManager.Instance.Navigate(ViewType.CardAccessMode);
            }
            else
            {
                WithdrawSum(keyCode);
            }
        }

        private void WithdrawSum(string keycode)
        {
            switch (keycode)
            {
                case "L1":
                    Withdraw("500");
                    break;
                case "L2":
                    Withdraw("400");
                    break;
                case "L3":
                    Withdraw("200");
                    break;
                case "L4":
                    Withdraw("100");
                    break;
                case "R1":
                    Withdraw("50");
                    break;
                case "R2":
                    Withdraw("20");
                    break;
                default:
                    break;
            }
        }

        private void Withdraw(string amount)
        {
            string res = ProcessorModel.Processor.handleInput(String.Concat("TRANSFERSUM=", amount, ";CARD=", CardNumber));
            if (res == "true")
            {
                Task.Delay(2000).ContinueWith(t => NavigationManager.Instance.Navigate(ViewType.CardAccessMode));
                CurrentBalance = ProcessorModel.Processor.handleInput("BALANCE");
                SuccessText = "Operation successful!";
                SumsDisplay = "Hidden";
            }
            else if(res == "card_not_enough")
            {
                Error = "Not enough money!";
            }
            else
            {
                Error = "Such card does not exist!";
            }
        }
    }
}
