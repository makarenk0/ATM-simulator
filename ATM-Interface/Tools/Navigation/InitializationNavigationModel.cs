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
                default:
                    throw new ArgumentOutOfRangeException(nameof(viewType), viewType, null);
            }

        }
    }
}
