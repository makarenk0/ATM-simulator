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
