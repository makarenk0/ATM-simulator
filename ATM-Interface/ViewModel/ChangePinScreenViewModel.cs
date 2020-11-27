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
    class ChangePinScreenViewModel : BaseViewModel
    {
        private String _oldPin;
        private String _newPin;
        private String _pinError;
        private String _newPinFormVisibility;
        private String _oldPinBackColor;
        private String _pinChangeSuccess;

        public string OldPin 
        { 
            get => _oldPin;
            set
            {
                _oldPin = value;
                OnPropertyChanged();
            }
        }
        public string NewPin 
        { 
            get => _newPin;
            set
            {
                _newPin = value;
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
        public string NewPinFormVisibility 
        { 
            get => _newPinFormVisibility;
            set
            {
                _newPinFormVisibility = value;
                OnPropertyChanged();
            }
        }

        public string OldPinBackColor 
        { 
            get => _oldPinBackColor;
            set
            {
                _oldPinBackColor = value;
                OnPropertyChanged();
            }
        }

        public string PinChangeSuccess 
        { 
            get => _pinChangeSuccess;
            set
            {
                _pinChangeSuccess = value;
                OnPropertyChanged();
            }
        }

        public void Init()
        {
            NewPinFormVisibility = "Hidden";
            OldPinBackColor = "White";
            OldPin = "";
            NewPin = "";
            PinError = "";
            PinChangeSuccess = "";
        }

        public void KeyPadClick(string keyCode)
        {
            if (keyCode[0] == 'N')
            {
                PinError = "";
                if (NewPinFormVisibility == "Hidden")
                {
                    if(OldPin.Length < 4)
                    {
                        OldPin += keyCode[1];
                    }
                }
                else
                {
                    if (NewPin.Length < 4)
                    {
                        NewPin += keyCode[1];
                    }
                }
            }
            else if (keyCode == "ENTER")
            {
                if (NewPinFormVisibility == "Hidden" && OldPin.Length == 4)
                {
                    if (ProcessorModel.Processor.handleInput(String.Concat("CHECKPIN=", OldPin)) == "true")
                    {
                        NewPinFormVisibility = "Visible";
                        OldPinBackColor = "Gray";
                    }
                    else
                    {
                        PinError = "Pin is not correct!";
                    }
                }
                else if(NewPin.Length == 4)
                {
                    ProcessorModel.Processor.handleInput(String.Concat("NEWPIN=", NewPin));
                    PinChangeSuccess = "Pin changed successfully";
                    Task.Delay(2000).ContinueWith(t => NavigationManager.Instance.Navigate(ViewType.CardAccessMode));
                }
            }
            else if (keyCode == "ERASE")
            {
                if (NewPinFormVisibility == "Hidden")
                {
                    if (OldPin.Length > 0)
                    {
                        OldPin = OldPin.Substring(0, OldPin.Length - 1);
                    }
                }
                else
                {
                    if (NewPin.Length > 0)
                    {
                        NewPin = NewPin.Substring(0, NewPin.Length - 1);
                    }
                }
            }
            else if (keyCode == "R4")
            {
                NavigationManager.Instance.Navigate(ViewType.CardAccessMode);
            }
        }

    }
}
