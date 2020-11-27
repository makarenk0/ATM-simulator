using System;

namespace ATM_Interface.Tools.Navigation
{
    internal enum ViewType
    {
        EnterCardNumber,
        ServiceMode,
        PinInputMode,
        CardAccessMode,
        BalanceView,
        PhoneBalanceRechargeMode,
        CustomSumMode,
        WithdrawCashMode,
        TransferSumMode,
        ChangePinMode
    }

    interface INavigationModel
    {
        void Navigate(ViewType viewType, String arg = "");
    }
}
