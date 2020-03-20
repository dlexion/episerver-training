using System.Web.Mvc;
using EPiServer.Core;
using EPiServer.Web;
using EPiServer.Web.Mvc;
using EpiserverSite.Business.Services;
using EpiserverSite.Models.Pages;
using EpiserverSite.Models.ViewModels;

namespace EpiserverSite.Controllers
{
    public class SearchPageController : PageController<SearchPage>
    {
        private readonly FindService _findService;
        private readonly SearchService _searchService;
        private readonly ContentReference[] _roots;
        private readonly int _maxResults;

        public SearchPageController(
            FindService findService,
            SearchService searchService)
        {
            _findService = findService;
            _searchService = searchService;
            _roots = new[]
            {
                SiteDefinition.Current.StartPage,
                SiteDefinition.Current.GlobalAssetsRoot,
                SiteDefinition.Current.SiteAssetsRoot
            };
            _maxResults = 10;
        }

        [HttpGet]
        public ActionResult Index(SearchPage currentPage)
        {
            return View("Index", new BaseViewModel<SearchPage>(currentPage));
        }

        [HttpPost]
        public ActionResult Search(SearchPage currentPage, string query)
        {
            var model = new CombinedSearchResultViewModel(currentPage);

            var searchResult = _searchService.Search(query, _roots, HttpContext, currentPage.Language?.Name, _maxResults);
            var findResult = _findService.Search(query, currentPage.Language?.Name, _maxResults);

            model.SearchItems = new SearchPageViewModel
            {
                TotalHits = searchResult.Count,
                Items = searchResult,
                SearchText = query,
            };

            model.FindItems = new SearchPageViewModel
            {
                TotalHits = findResult.Count,
                Items = findResult,
                SearchText = query,
            };

            return View("Result", model);
        }
    }
}