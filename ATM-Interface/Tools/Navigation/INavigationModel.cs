namespace ATM_Interface.Tools.Navigation
{
    internal enum ViewType
    {
        EnterCardNumber,
        ServiceMode,
        PinInputMode,
        CardAccessMode
    }

    interface INavigationModel
    {
        void Navigate(ViewType viewType);
    }
}
