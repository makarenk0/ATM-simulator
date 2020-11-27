using ATM_Interface.Models;
using ATM_Interface.Tools.Managers;
using ATM_Interface.Tools.MVVM;
using ATM_Interface.Tools.Navigation;

namespace ATM_Interface.ViewModel
{
    class CardAccessViewModel : BaseViewModel
    {

        public void Init()
        {

        }

        public void KeyPadClick(string keyCode)
        {
            switch (keyCode)
            {
                case "L1":
                    NavigationManager.Instance.Navigate(ViewType.BalanceView);
                    break;
                case "L2":
                    NavigationManager.Instance.Navigate(ViewType.PhoneBalanceRechargeMode);
                    break;
                case "L3":
                    NavigationManager.Instance.Navigate(ViewType.WithdrawCashMode);
                    break;
                case "L4":
                    NavigationManager.Instance.Navigate(ViewType.TransferSumMode);
                    break;
                case "R1":
                    NavigationManager.Instance.Navigate(ViewType.ChangePinMode);
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
