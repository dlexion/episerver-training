using System.Web.Mvc;
using EPiServer.Web.Mvc;
using EpiserverSite.Business.Helpers;
using EpiserverSite.Models.Blocks;

namespace EpiserverSite.Controllers.Blocks
{
    public class PageListingBlockController : BlockController<PageListingBlock>
    {
        private readonly INavigationHelper _helper;

        public PageListingBlockController(INavigationHelper helper)
        {
            _helper = helper;
        }

        public override ActionResult Index(PageListingBlock currentBlock)
        {
            var data = _helper.GetPageChildren(currentBlock.Root);

            ViewData["PageCollection"] = data;

            return PartialView("Blocks/PageListingBlock", currentBlock);
        }
    }
}