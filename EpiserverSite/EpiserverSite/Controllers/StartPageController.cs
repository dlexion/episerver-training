using System.Web.Mvc;
using EPiServer.Web.Mvc;
using EpiserverSite.Models.Pages;

namespace EpiserverSite.Controllers
{
    public class StartPageController : PageController<StartPage>
    {
        public ActionResult Index(StartPage currentPage)
        {
            return View(currentPage);
        }
    }
}