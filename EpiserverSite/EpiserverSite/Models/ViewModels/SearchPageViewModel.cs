using System.Collections.Generic;
using EpiserverSite.Models.Pages;

namespace EpiserverSite.Models.ViewModels
{
    public class SearchPageViewModel : BaseViewModel<SearchPage>
    {
        public SearchPageViewModel(SearchPage currentPage) : base(currentPage)
        {
        }

        public string SearchText { get; set; }

        public int TotalHits { get; set; }

        public IEnumerable<SearchResult> Items { get; set; }
    }
}