using System.Collections.Generic;
using System.Linq;
using EPiServer;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.Filters;
using EPiServer.ServiceLocation;

namespace EpiserverSite.Business.Helpers
{
    [ServiceConfiguration(typeof(IPageHelper))]
    public class PageHelper : IPageHelper
    {
        private readonly IContentTypeRepository _contentTypeRepository;
        private readonly IPageCriteriaQueryService _queryService;

        public PageHelper(IContentTypeRepository contentTypeRepository, IPageCriteriaQueryService queryService)
        {
            _contentTypeRepository = contentTypeRepository;
            _queryService = queryService;
        }

        public IEnumerable<PageType> GetAllPageTypes()
        {
            return _contentTypeRepository.List().OfType<PageType>();
        }

        public PageDataCollection GetPagesByPageType(string pageType)
        {
            var criterias = new PropertyCriteriaCollection();

            var criteria = new PropertyCriteria
            {
                Condition = CompareCondition.Equal,
                Name = "PageTypeID",
                Type = PropertyDataType.PageType,
                Value = pageType,
                Required = true,
            };

            criterias.Add(criteria);

            var pages = _queryService.FindPagesWithCriteria(ContentReference.RootPage, criterias);

            return pages;
        }
    }
}