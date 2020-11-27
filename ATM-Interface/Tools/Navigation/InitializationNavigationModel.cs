using System;
using ATM_Interface.View;
//using EnterCardNumberView = ATM_Interface.View.EnterCardNumberScreen;
//using ServiceModeView = ATM_Interface.View.ServiceModeScreen;

namespace ATM_Interface.Tools.Navigation
{
    internal class InitializationNavigationModel : BaseNavigationModel
    {
        public InitializationNavigationModel(IContentOwner contentOwner) : base(contentOwner)
        {
            
        }
   
        protected override void InitializeView(ViewType viewType)
        {
            switch (viewType)
            {
                case ViewType.EnterCardNumber:
                    ViewsDictionary.Add(viewType, new EnterCardNumberScreen());
                    break;
                case ViewType.ServiceMode:
                    ViewsDictionary.Add(viewType, new ServiceModeScreen());
                    break;
                case ViewType.PinInputMode:
                    ViewsDictionary.Add(viewType, new PinInputScreen());
                    break;
                case ViewType.CardAccessMode:
                    ViewsDictionary.Add(viewType, new CardAccessScreen());
                    break;
                case ViewType.BalanceView:
                    ViewsDictionary.Add(viewType, new BalanceViewScreen());
                    break;
                case ViewType.PhoneBalanceRechargeMode:
                    ViewsDictionary.Add(viewType, new PhoneBalRechargeScreen());
                    break;
                case ViewType.CustomSumMode:
                    ViewsDictionary.Add(viewType, new CustomSumWithdrawScreen());
                    break;
                case ViewType.WithdrawCashMode:
                    ViewsDictionary.Add(viewType, new WithdrawCashScreen());
                    break;
                case ViewType.TransferSumMode:
                    ViewsDictionary.Add(viewType, new TransferSumScreen());
                    break;
                case ViewType.ChangePinMode:
                    ViewsDictionary.Add(viewType, new ChangePinScreen());
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(viewType), viewType, null);
            }

        }
    }
}
