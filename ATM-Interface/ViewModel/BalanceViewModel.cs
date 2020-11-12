using ATM_Interface.Models;
using ATM_Interface.Tools.Managers;
using ATM_Interface.Tools.MVVM;
using ATM_Interface.Tools.Navigation;

namespace ATM_Interface.ViewModel
{
    class BalanceViewModel : BaseViewModel
    {
        private string _currentBalance;

        public string CurrentBalance
        {
            get => _currentBalance;
            set
            {
                _currentBalance = value;
                OnPropertyChanged();
            }
        }

        public void KeyPadClick(string keyCode)
        {
            if (keyCode == "R4")
            {
                NavigationManager.Instance.Navigate(ViewType.CardAccessMode);
            }
        }

        public void Init()
        {
            CurrentBalance = ProcessorModel.Processor.handleInput("BALANCE");
        }
    }
}
