using EPiServer.Core;
using EpiserverSite.Models.Pages;

namespace EpiserverSite.Models.ViewModels
{
    public class BasePageWithNavigationViewModel<T> : BaseViewModel<T>, IPageWithNavigationViewModel<T>
        where T : PageWithNavigation
    {
        public BasePageWithNavigationViewModel(T currentPage) : base(currentPage)
        {
        }

        public PageDataCollection Listing { get; set; }
    }
}