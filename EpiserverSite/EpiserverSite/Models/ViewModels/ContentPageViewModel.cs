using EpiserverSite.Models.Pages;

namespace EpiserverSite.Models.ViewModels
{
    public class ContentPageViewModel : BaseViewModel<ContentPage>
    {
        public ContentPageViewModel(ContentPage currentPage) : base(currentPage)
        {
        }
    }
}