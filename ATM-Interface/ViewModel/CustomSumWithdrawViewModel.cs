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
    class CustomSumWithdrawViewModel : BaseViewModel
    {

        private string _currentBalance;
        private string _withdrawSum;
        private string _withdrawSumError;
        private string _successText;
        private string _cartToTransfer;



        public string CurrentBalance
        {
            get => _currentBalance;
            set
            {
                _currentBalance = value;
                OnPropertyChanged();
            }
        }

        public string SuccessText
        {
            get => _successText;
            set
            {
                _successText = value;
                OnPropertyChanged();
            }
        }

        public string WithdrawSum
        {
            get => _withdrawSum;
            set
            {
                _withdrawSum = value;
                OnPropertyChanged();
            }
        }

        public string WithdrawSumError
        {
            get => _withdrawSumError;
            set
            {
                _withdrawSumError = value;
                OnPropertyChanged();
            }
        }

        public void Init(String arg)
        {
            if (arg.Length != 0)
            {
                _cartToTransfer = arg;
            }
          
            CurrentBalance = ProcessorModel.Processor.handleInput("BALANCE");
            WithdrawSum = "";
            WithdrawSumError = "";
            SuccessText = "";
        }

        public void KeyPadClick(string keyCode)
        {
            if (keyCode[0] == 'N' && WithdrawSum.Length < 6)
            {
                WithdrawSum += keyCode[1];
                WithdrawSumError = "";
            }
            else if(keyCode == "ENTER")
            {
                Withdraw(WithdrawSum);
            }
            else if (keyCode == "ERASE")
            {
                WithdrawSum = String.IsNullOrEmpty(WithdrawSum) ? "" : WithdrawSum.Substring(0, WithdrawSum.Length - 1);
                WithdrawSumError = "";
            }
            else if (keyCode == "R4")
            {
                NavigationManager.Instance.Navigate(ViewType.CardAccessMode);
            }
        }

        private void Withdraw(string amount)
        {
            string res = ProcessorModel.Processor.handleInput(_cartToTransfer.Length != 0 ? String.Concat("TRANSFERSUM=", amount, ";CARD=", _cartToTransfer) : String.Concat("WITHDRAWSUM=", amount));
            if (res == "true")
            {
                Task.Delay(2000).ContinueWith(t => NavigationManager.Instance.Navigate(ViewType.CardAccessMode));
                CurrentBalance = ProcessorModel.Processor.handleInput("BALANCE");
                SuccessText = "Operation successful!";
            }
            else
            {
                WithdrawSumError = "Not enough money!";
            }
        }
    }
}
