using System.Web.Mvc;
using EPiServer.Core;
using EPiServer.Framework.DataAnnotations;
using EPiServer.Framework.Web;
using EPiServer.Web;
using EPiServer.Web.Mvc;
using EpiserverSite.Business.Interfaces;
using EpiserverSite.Models.ViewModels;

namespace EpiserverSite.Controllers
{
    [TemplateDescriptor(
        Inherited = true,
        TemplateTypeCategory = TemplateTypeCategories.MvcController,
        Tags = new[] { RenderingTags.Preview },
        AvailableWithoutTag = false)]
    public class PreviewController : ActionControllerBase, IRenderTemplate<IPreviewableBlock>
    {
        public ActionResult Index(IContent currentContent)
        {
            var model = new PreviewViewModel(currentContent);

            var contentArea = new ContentArea();

            contentArea.Items.Add(new ContentAreaItem
            {
                ContentLink = currentContent.ContentLink
            });

            model.ContentArea = contentArea;

            return View(model);
        }
    }
}