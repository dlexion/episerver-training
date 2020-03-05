using EpiserverSite.Models.Pages;

namespace EpiserverSite.Models.ViewModels
{
    public class NewsItemPageViewModel : BasePageWithNavigationViewModel<NewsItemPage>
    {
        public NewsItemPageViewModel(NewsItemPage currentPage)
            : base(currentPage)
        {
        }
    }
}