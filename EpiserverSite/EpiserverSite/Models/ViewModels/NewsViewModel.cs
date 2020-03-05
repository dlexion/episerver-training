using EpiserverSite.Models.Pages;

namespace EpiserverSite.Models.ViewModels
{
    public class NewsViewModel : BasePageWithNavigationViewModel<NewsPage>
    {
        public NewsViewModel(NewsPage currentPage)
            : base(currentPage)
        {
        }
    }
}