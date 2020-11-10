using ATM_Interface.Models;
using ATM_Interface.Tools.Managers;
using ATM_Interface.Tools.MVVM;
using ATM_Interface.Tools.Navigation;
using System;
using System.Collections.Generic;
using System.Text;

namespace ATM_Interface.ViewModel
{
    class PinInputScreenViewModel : BaseViewModel
    {
        private String _pincode = "";
        private String _pinError = "";
        private int _attempts;

        public PinInputScreenViewModel()
        {
            
        }

        public void Init()
        {
            _attempts = 3;
            Pincode = "";
        }

        public string Pincode
        {
            get { return _pincode; }
            set
            {
                _pincode = value;
                OnPropertyChanged();
            }
        }

        public string PinError
        {
            get => _pinError;
            set
            {
                _pinError = value;
                OnPropertyChanged();
            }
        }

        public void KeyPadClick(string keyCode)
        {


            if (keyCode[0] == 'N' && Pincode.Length < 4)
            {
                Pincode += keyCode[1];
                PinError = "";
            }
            else if (keyCode == "ERASE")
            {
                Pincode = String.IsNullOrEmpty(Pincode) ? "" : Pincode.Substring(0, Pincode.Length - 1);
                PinError = "";
            }
            else if (keyCode == "ENTER")
            {
                if (Pincode.Length != 4)
                {
                    PinError = "Pincode is not full!";
                }
                else
                {
                    if (ProcessorModel.Processor.handleInput(Pincode) == "true")
                    {
                        NavigationManager.Instance.Navigate(ViewType.CardAccessMode);
                    }
                    else
                    {
                        if(_attempts == 1)
                        {
                            ProcessorModel.Processor.handleInput("BLOCK_CARD");
                            PinError = "Your card is blocked! \n Please, contact the support service.";
                        }
                        else
                        {
                            --_attempts;
                            PinError = String.Concat("Pincode is incorrect!\n", "Attempts left: ", _attempts);
                        }
                        
                    }
                }
            }
            else if(keyCode == "R4")
            {
                ProcessorModel.Processor.popState();
                NavigationManager.Instance.Navigate(ViewType.EnterCardNumber);
            }
        }
    }
}
