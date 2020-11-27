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


            if (keyCode[0] == 'N' && Pincode.Length < 4 && _attempts > 0)
            {
                Pincode += keyCode[1];
                PinError = "";
            }
            else if (keyCode == "ERASE" && _attempts > 0)
            {
                Pincode = String.IsNullOrEmpty(Pincode) ? "" : Pincode.Substring(0, Pincode.Length - 1);
                PinError = "";
            }
            else if (keyCode == "ENTER" && _attempts > 0)
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
                        --_attempts;
                        if (_attempts == 0)
                        {
                            ProcessorModel.Processor.handleInput("BLOCK_CARD");
                            PinError = "Your card is blocked! \n Please, contact the support service.";
                        }
                        else
                        {    
                            PinError = String.Concat("Pincode is incorrect!\n", "Attempts left: ", _attempts);
                            Pincode = "";
                        }

                    }
                }
            }
            else if(keyCode == "R4")
            {
                ProcessorModel.Processor.popState();
                PinError = "";
                NavigationManager.Instance.Navigate(ViewType.EnterCardNumber);
            }
        }
    }
}
