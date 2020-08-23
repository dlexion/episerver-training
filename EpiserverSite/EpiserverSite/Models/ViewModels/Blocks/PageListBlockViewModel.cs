using EPiServer.Core;
using EpiserverSite.Models.Blocks;

namespace EpiserverSite.Models.ViewModels.BlockViewModels
{
    public class PageListBlockViewModel
    {
        public PageListBlockViewModel(PageListBlock currentBlock,
            PageDataCollection pageCollection,
            PageData rootPage)
        {
            CurrentBlock = currentBlock;
            PageCollection = pageCollection;
            RootPage = rootPage;
        }

        public PageListBlock CurrentBlock { get; set; }

        public PageDataCollection PageCollection { get; set; }

        public PageData RootPage { get; set; }
    }
}