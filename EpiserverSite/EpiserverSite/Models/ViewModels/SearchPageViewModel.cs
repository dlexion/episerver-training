using System.Collections.Generic;

namespace EpiserverSite.Models.ViewModels
{
    public class SearchPageViewModel
    {
        public string SearchText { get; set; }

        public int TotalHits { get; set; }

        public IEnumerable<SearchResult> Items { get; set; }
    }
}