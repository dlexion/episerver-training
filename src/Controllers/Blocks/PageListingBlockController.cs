using System.Web.Mvc;
using EPiServer.Web.Mvc;
using EpiserverSite.Business.Helpers;
using EpiserverSite.Models.Blocks;
using EpiserverSite.Models.ViewModels.Blocks;

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
            var pages = _helper.GetPageChildren(currentBlock.Root);

            return PartialView("Blocks/PageListingBlock", new PageListingBlockViewModel(currentBlock, pages));
        }
    }
}