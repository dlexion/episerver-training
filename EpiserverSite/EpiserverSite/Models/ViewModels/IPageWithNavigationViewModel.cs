using EPiServer.Core;
using EpiserverSite.Models.Pages;

namespace EpiserverSite.Models.ViewModels
{
    public interface IPageWithNavigationViewModel<out T> : IPageViewModel<T>
        where T : PageWithNavigation
    {
        PageDataCollection Listing { get; set; }
    }
}