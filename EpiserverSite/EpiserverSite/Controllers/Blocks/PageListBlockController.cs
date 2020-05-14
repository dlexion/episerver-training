using System.Web.Mvc;
using EPiServer;
using EPiServer.Core;
using EPiServer.Filters;
using EPiServer.Web.Mvc;
using EpiserverSite.Models.Blocks;
using EpiserverSite.Models.ViewModels.BlockViewModels;

namespace EpiserverSite.Controllers.Blocks
{
    public class PageListBlockController : BlockController<PageListBlock>
    {
        private readonly IPageCriteriaQueryService _queryService;
        private readonly IContentRepository _contentRepository;

        public PageListBlockController(IPageCriteriaQueryService queryService,
            IContentRepository contentRepository)
        {
            _queryService = queryService;
            _contentRepository = contentRepository;
        }

        public override ActionResult Index(PageListBlock currentBlock)
        {
            PropertyCriteriaCollection criterias = SetupCriterias(currentBlock.PageType);

            var foundPages = _queryService.FindPagesWithCriteria(currentBlock.Root.ToPageReference(), criterias);
            var rootPage = _contentRepository.Get<PageData>(currentBlock.Root);

            return PartialView("Blocks/PageListBlock", new PageListBlockViewModel(currentBlock, foundPages, rootPage));
        }

        private PropertyCriteriaCollection SetupCriterias(string pageTypeId)
        {
            return new PropertyCriteriaCollection()
            {
                new PropertyCriteria
                {
                    Condition = CompareCondition.Equal,
                    Name = "PageTypeID",
                    Type = PropertyDataType.PageType,
                    Value = pageTypeId,
                    Required = true
                }
            };
        }
    }
}