using System.Web.Mvc;
using EPiServer.Web.Mvc;
using EpiserverSite.Models.Pages;
using EpiserverSite.Models.ViewModels;

namespace EpiserverSite.Controllers
{
    public class SearchPageController : PageController<SearchPage>
    {
        public ActionResult Index(SearchPage currentPage)
        {
            return View("Index", new BaseViewModel<SearchPage>(currentPage));
        }
    }
}