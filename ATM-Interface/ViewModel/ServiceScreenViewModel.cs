using ATM_Interface.Models;
using ATM_Interface.Tools.Managers;
using ATM_Interface.Tools.MVVM;
using ATM_Interface.Tools.Navigation;
using System;
using System.Collections.Generic;
using System.Text;

namespace ATM_Interface.ViewModel
{
    class ServiceScreenViewModel : BaseViewModel
    {
        private String _blockedCardsAmount;
        private bool _rechargeATMCashMode;
        private string _rechargeFormVisibility;
        private string _cashToRecharge;
        private string _atmCash;


        public ServiceScreenViewModel()
        {
           
        }

        public void Init()
        {
            ProcessorModel.Processor.handleInput("SERVICE_MODE");
            ATMCash = ProcessorModel.Processor.handleInput("ATM_CASH");
            BlockedCardsAmount = ProcessorModel.Processor.handleInput("BLOCKED_AMOUNT");
            _rechargeATMCashMode = false;
            RechargeFormVisibility = "Hidden";
            CashToRecharge = "";
        }

        public String BlockedCardsAmount 
        { 
            get => _blockedCardsAmount;
            set
            {
                _blockedCardsAmount = value;
                OnPropertyChanged();
            }
        }

        public string RechargeFormVisibility 
        { 
            get => _rechargeFormVisibility;
            set
            {
                _rechargeFormVisibility = value;
                OnPropertyChanged();
            }
        }

        public string CashToRecharge 
        { 
            get => _cashToRecharge;
            set
            {
                _cashToRecharge = value;
                OnPropertyChanged();
            }
        }

        public string ATMCash
        {
            get => _atmCash;
            set
            {
                _atmCash = value;
                OnPropertyChanged();
            }
        }

        public void KeyPadClick(string keyCode)
        {
            if (keyCode[0] == 'N' && CashToRecharge.Length < 8)
            {
                CashToRecharge += keyCode[1];
            }
            else if (keyCode == "L1")
            {
                ProcessorModel.Processor.handleInput("TAKE_BLOCKED_CARDS");
                BlockedCardsAmount = "0";
            }
            else if (keyCode == "L2")
            {
                _rechargeATMCashMode = true;
                RechargeFormVisibility = "Visible";
            }
            else if(keyCode == "R4")
            {
                ProcessorModel.Processor.popState();
                NavigationManager.Instance.Navigate(ViewType.EnterCardNumber);
            }
            else if (keyCode == "ENTER" && _rechargeATMCashMode)
            {
                RechargeFormVisibility = "Hidden";
                _rechargeATMCashMode = false;
                ProcessorModel.Processor.handleInput(CashToRecharge);
                ATMCash = ProcessorModel.Processor.handleInput("ATM_CASH");
            }
            else if(keyCode == "ERASE" && _rechargeATMCashMode && CashToRecharge.Length > 0)
            {
                CashToRecharge = CashToRecharge.Substring(0, CashToRecharge.Length - 1);
            }
            else if (keyCode == "CANCEL" && _rechargeATMCashMode)
            {
                RechargeFormVisibility = "Hidden";
                _rechargeATMCashMode = false;
            }




        }
    }
}
