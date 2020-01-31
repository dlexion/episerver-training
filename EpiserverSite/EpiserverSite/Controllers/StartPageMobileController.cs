using System.Web.Mvc;
using EPiServer.Framework.DataAnnotations;
using EPiServer.Framework.Web;
using EPiServer.Web.Mvc;
using EpiserverSite.Models.Pages;
using EpiserverSite.Models.ViewModels;

namespace EpiserverSite.Controllers
{
    [TemplateDescriptor(Tags = new [] { RenderingTags.Mobile })]
    public class StartPageMobileController : PageController<StartPage>
    {
        public ActionResult Index(StartPage currentPage)
        {
            return View("~/Views/StartPage/Index.mobile.cshtml", new StartPageViewModel(currentPage));
        }
    }
}