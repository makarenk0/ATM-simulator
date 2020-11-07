using System.Windows.Controls;

namespace ATM_Interface.Tools.Navigation
{
    internal interface IContentOwner
    {
        INavigatable Content { get; set; }
    }
}
