using System.Web.Mvc;
using EPiServer.Web.Mvc;
using EpiserverSite.Models.Pages;
using EpiserverSite.Models.ViewModels;

namespace EpiserverSite.Controllers
{
    public class NewsPageController : PageController<NewsPage>
    {
        public ActionResult Index(NewsPage currentPage)
        {
            return View(new NewsViewModel(currentPage));
        }
    }
}