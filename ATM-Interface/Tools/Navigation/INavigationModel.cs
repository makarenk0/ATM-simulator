namespace ATM_Interface.Tools.Navigation
{
    internal enum ViewType
    {
        EnterCardNumber
    }

    interface INavigationModel
    {
        void Navigate(ViewType viewType);
    }
}
