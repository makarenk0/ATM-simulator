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

        public ServiceScreenViewModel()
        {
           
        }

        public void Init()
        {
            ProcessorModel.Processor.handleInput("SERVICE_MODE");
            BlockedCardsAmount = ProcessorModel.Processor.handleInput("BLOCKED_AMOUNT");
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
        public void KeyPadClick(string keyCode)
        {
            switch (keyCode)
            {
                case "L1":
                    ProcessorModel.Processor.handleInput("TAKE_BLOCKED_CARDS");
                    BlockedCardsAmount = "0";
                    break;
                case "R4":
                    ProcessorModel.Processor.popState();
                    NavigationManager.Instance.Navigate(ViewType.EnterCardNumber);
                    break;
                default:
                    break;

            }
        }
    }
}
