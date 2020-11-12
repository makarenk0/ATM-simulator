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
    class WithdrawCashViewModel : BaseViewModel
    {
       
        
        private String _withdrawCashError;
        private String _successText;

    
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

        

        public string WithdrawCashError
        {
            get => _withdrawCashError;
            set
            {
                _withdrawCashError = value;
                OnPropertyChanged();
            }
        }

        public void Init()
        {
            WithdrawCashError = "";
            SuccessText = "";
            CurrentBalance = ProcessorModel.Processor.handleInput("BALANCE");
        }

        public void KeyPadClick(string keyCode)
        {
            if (keyCode == "R4")
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
                    Withdraw("2000");
                    break;
                case "L2":
                    Withdraw("1500");
                    break;
                case "L3":
                    Withdraw("1000");
                    break;
                case "L4":
                    Withdraw("500");
                    break;
                case "R1":
                    Withdraw("400");
                    break;
                case "R2":
                    Withdraw("200");
                    break;
                case "R3":
                    Withdraw("100");
                    break;
                default:
                    break;
            }
        }

        private void Withdraw(string amount)
        {
            string res = ProcessorModel.Processor.handleInput("WITHDRAWCASH=" + amount);
            if (res == "true")
            {
                Task.Delay(2000).ContinueWith(t => NavigationManager.Instance.Navigate(ViewType.CardAccessMode));
                CurrentBalance = ProcessorModel.Processor.handleInput("BALANCE");
                WithdrawCashError = "";
                SuccessText = "Operation successful!";
            }
            else if(res == "card_not_enough")
            {
                WithdrawCashError = "Not enough money!";
            }
            else
            {
                WithdrawCashError = "ATM does not have enough cash";
            }
        }

    }
}
