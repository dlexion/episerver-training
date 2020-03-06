using EPiServer.Core;
using EpiserverSite.Models.Blocks;

namespace EpiserverSite.Models.ViewModels.Blocks
{
    public class PageListingBlockViewModel
    {
        public PageListingBlockViewModel(PageListingBlock currentBlock, PageDataCollection pages)
        {
            CurrentBlock = currentBlock;
            Pages = pages;
        }

        public PageListingBlock CurrentBlock { get; set; }

        public PageDataCollection Pages { get; set; }
    }
}