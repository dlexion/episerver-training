using EpiserverSite.Models.Pages;

namespace EpiserverSite.Models.ViewModels
{
    public class CombinedSearchResultViewModel : BaseViewModel<SearchPage>
    {
        public CombinedSearchResultViewModel(SearchPage currentPage)
            : base(currentPage)
        {
        }

        public SearchPageViewModel SearchItems { get; set; }

        public SearchPageViewModel FindItems { get; set; }
    }
}