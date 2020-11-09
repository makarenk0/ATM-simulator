namespace ATM_Interface.Tools.Navigation
{
    internal enum ViewType
    {
        EnterCardNumber,
        ServiceMode
    }

    interface INavigationModel
    {
        void Navigate(ViewType viewType);
    }
}
