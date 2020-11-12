using ATM_Interface.Models;
using ATM_Interface.Tools.Managers;
using ATM_Interface.Tools.MVVM;
using ATM_Interface.Tools.Navigation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ATM_Interface.ViewModel
{
    class PhoneBalRechargeViewModel : BaseViewModel
    {
        private String _phoneNumber;
        private String _phoneBackColor;
        private String _phoneNumberError;
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

        public string PhoneNumber
        {
            get { return _phoneNumber; }
            set
            {
                _phoneNumber = value;
                OnPropertyChanged();
            }
        }

        public string PhoneNumberError
        {
            get => _phoneNumberError;
            set
            {
                _phoneNumberError = value;
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

        public string PhoneBackColor
        {
            get => _phoneBackColor;
            set
            {
                _phoneBackColor = value;
                OnPropertyChanged();
            }
        }

        public void Init()
        {
            SumsDisplay = "Hidden";
            PhoneBackColor = "White";
            PhoneNumber = "+38";
            PhoneNumberError = "";
            SuccessText = "";
            CurrentBalance = ProcessorModel.Processor.handleInput("BALANCE");
        }

        public void KeyPadClick(string keyCode)
        {
            if (keyCode[0] == 'N' && PhoneNumber.Length < 13 && SumsDisplay == "Hidden")
            {
                PhoneNumber += keyCode[1];
                PhoneNumberError = "";
            }
            else if (keyCode == "ERASE" && PhoneNumber.Length > 3 && SumsDisplay == "Hidden")
            {
                PhoneNumber = PhoneNumber.Substring(0, PhoneNumber.Length - 1);
                PhoneNumberError = "";
            }
            else if (keyCode == "ENTER")
            {
                if (PhoneNumber.Length != 13)
                {
                    PhoneNumberError = "Phone number is not valid!";
                }
                else
                {
                    SumsDisplay = "Visible";
                    PhoneBackColor = "Gray";
                }
            }
            else if (keyCode == "CANCEL" && SumsDisplay == "Visible")
            {
                SumsDisplay = "Hidden";
                PhoneBackColor = "White";
            }
            else if (keyCode == "R3")
            {
                NavigationManager.Instance.Navigate(ViewType.CustomSumMode);
            }
            else if(keyCode == "R4")
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
            string res = ProcessorModel.Processor.handleInput("WITHDRAWSUM=" + amount);
            if (res == "true")
            {
                Task.Delay(2000).ContinueWith(t => NavigationManager.Instance.Navigate(ViewType.CardAccessMode));
                CurrentBalance = ProcessorModel.Processor.handleInput("BALANCE");
                SuccessText = "Operation successful!";
                SumsDisplay = "Hidden";
            }
            else
            {
                PhoneNumberError = "Not enough money!";
            }
        }


    }
}
