using EpiserverSite.Models.Pages;

namespace EpiserverSite.Models.ViewModels
{
    public interface IPageViewModel<out T> where T : BasePage
    {
        LayoutViewModel Layout { get; set; }

        T CurrentPage { get; }
    }
}