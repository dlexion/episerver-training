using System.Linq;
using System.Web.Mvc;
using EPiServer.Core;
using EPiServer.Search;
using EPiServer.Web;
using EPiServer.Web.Mvc;
using EPiServer.Web.Routing;
using EpiserverSite.Business.Services;
using EpiserverSite.Models;
using EpiserverSite.Models.Pages;
using EpiserverSite.Models.ViewModels;

namespace EpiserverSite.Controllers
{
    public class SearchPageController : PageController<SearchPage>
    {
        private readonly FindService _findService;
        private readonly SearchService _searchService;
        private readonly ContentSearchHandler _contentSearchHandler;
        private readonly IUrlResolver _urlResolver;
        private readonly ContentReference[] _roots;
        private readonly int _maxResults;

        public SearchPageController(
            FindService findService,
            SearchService searchService,
            ContentSearchHandler contentSearchHandler,
            IUrlResolver urlResolver)
        {
            _findService = findService;
            _searchService = searchService;
            _contentSearchHandler = contentSearchHandler;
            _urlResolver = urlResolver;
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
            var result = _searchService.Search(query, _roots, HttpContext, currentPage.Language?.Name, _maxResults);

            var model = new SearchPageViewModel(currentPage)
            {
                SearchText = query,
                TotalHits = result.TotalHits,
                Items = result.IndexResponseItems.Select(x => new SearchResult
                {
                    Name = x.Title,
                    Url = GetUrl(x),
                }),
            };

            var result2 = _findService.Search(query);

            return View("Result", model);
        }

        private string GetUrl(IndexResponseItem item)
        {
            return _urlResolver.GetUrl(_contentSearchHandler.GetContent<IContent>(item).ContentLink);
        }
    }
}