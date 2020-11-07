using System;
using ATM_Interface.View;
using UserAddingView = ATM_Interface.View.EnterCardNumberScreen;

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
                default:
                    throw new ArgumentOutOfRangeException(nameof(viewType), viewType, null);
            }

        }
    }
}
