using System.Web.Mvc;
using EPiServer.Framework.DataAnnotations;
using EPiServer.Framework.Web;
using EPiServer.Web.Mvc;
using EpiserverSite.Models.Pages;
using EpiserverSite.Models.ViewModels;

namespace EpiserverSite.Controllers
{
    [TemplateDescriptor(TemplateTypeCategory = TemplateTypeCategories.MvcPartialController, Tags = new[] { "RightAlign" })]
    public class ContentPageRightAlignPartialController : PageController<ContentPage>
    {
        public ActionResult Index(ContentPage currentPage)
        {
            return PartialView("~/Views/ContentPage/RightAlignIndex.cshtml", new ContentPageViewModel(currentPage));
        }
    }
}