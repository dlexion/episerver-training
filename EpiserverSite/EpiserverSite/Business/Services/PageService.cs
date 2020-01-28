using EPiServer;
using EPiServer.Core;
using EPiServer.DataAccess;
using EPiServer.Security;
using EpiserverSite.Models;
using EpiserverSite.Models.Pages;

namespace EpiserverSite.Business.Services
{
    public class PageService<T, TUpdateModel> : IPageService<T, TUpdateModel>
        where T : BasePage
        where TUpdateModel : IUpdateBasePageModel
    {
        private readonly IContentRepository _contentRepository;

        public PageService(IContentRepository contentRepository)
        {
            _contentRepository = contentRepository;
        }

        public bool TryCreate(ContentReference parent, TUpdateModel updateModel, out T newPage)
        {
            newPage = null;

            if (!_contentRepository.TryGet<BasePage>(updateModel.CurrentPageId, out _))
            {
                return false;
            }

            newPage = _contentRepository.GetDefault<T>(parent);
            newPage.PageName = updateModel.PageName;

            _contentRepository.Save(newPage, SaveAction.Publish, AccessLevel.NoAccess);

            updateModel.CurrentPageId = newPage.ContentLink;

            newPage = UpdatePageContent(updateModel);

            _contentRepository.Save(newPage, SaveAction.Publish, AccessLevel.NoAccess);

            return true;
        }

        public bool TryUpdate(TUpdateModel updateModel, out T updatedPage)
        {
            if (!_contentRepository.TryGet<T>(updateModel.CurrentPageId, out updatedPage))
            {
                return false;
            }

            updatedPage = UpdatePageContent(updateModel);

            _contentRepository.Save(updatedPage, SaveAction.Publish, AccessLevel.NoAccess);

            return true;
        }

        protected virtual T UpdatePageContent(IUpdateBasePageModel updateModel)
        {
            if (!_contentRepository.TryGet<T>(updateModel.CurrentPageId, out var existingPage))
            {
                return existingPage;
            }

            var updatedPage = (T)existingPage.CreateWritableClone();

            if (!string.IsNullOrEmpty(updateModel.PageName))
            {
                updatedPage.PageName = updateModel.PageName;
            }
            updatedPage.OpenGraphTitle = updateModel.OpenGraphTitle;
            updatedPage.Robots = updateModel.Robots;

            return updatedPage;
        }
    }
}