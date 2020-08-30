using System.Web.Mvc;
using EPiServer.Framework.DataAnnotations;
using EPiServer.Framework.Web;
using EPiServer.Web.Mvc;
using EpiserverSite.Models.Pages;
using EpiserverSite.Models.ViewModels;

namespace EpiserverSite.Controllers
{
    [TemplateDescriptor(TemplateTypeCategory = TemplateTypeCategories.MvcPartialController)]
    public class ContentPagePartialController : PageController<ContentPage>
    {
        public ActionResult Index(ContentPage currentPage)
        {
            return PartialView("~/Views/ContentPage/Index.cshtml", new ContentPageViewModel(currentPage));
        }
    }
}