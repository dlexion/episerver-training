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
        private const int MaxResults = 10;
        private static readonly ContentReference[] Roots =
        {
            SiteDefinition.Current.StartPage,
            SiteDefinition.Current.GlobalAssetsRoot,
            SiteDefinition.Current.SiteAssetsRoot
        };

        private readonly FindService _findService;
        private readonly SearchService _searchService;

        public SearchPageController(
            FindService findService,
            SearchService searchService)
        {
            _findService = findService;
            _searchService = searchService;
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

            var searchResult = _searchService.Search(query, Roots, HttpContext, currentPage.Language?.Name, MaxResults);
            var findResult = _findService.Search(query, currentPage.Language?.Name, MaxResults);

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