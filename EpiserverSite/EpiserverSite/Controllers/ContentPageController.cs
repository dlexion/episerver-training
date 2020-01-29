using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using EPiServer;
using EPiServer.Core;
using EPiServer.Framework.DataAnnotations;
using EPiServer.Web.Mvc;
using EpiserverSite.Models.Pages;
using EpiserverSite.Models.ViewModels;

namespace EpiserverSite.Controllers
{
    public class ContentPageController : PageController<ContentPage>
    {
        public ActionResult Index(ContentPage currentPage)
        {
            return View("Index", new ContentPageViewModel(currentPage));
        }
    }
}