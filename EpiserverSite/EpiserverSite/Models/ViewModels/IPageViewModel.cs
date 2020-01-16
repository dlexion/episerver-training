using EPiServer.Core;

namespace EpiserverSite.Models.ViewModels
{
    public interface IPageViewModel<out T> where T : PageData
    {
        LayoutViewModel Layout { get; set; }

        T CurrentPage { get; }
    }
}