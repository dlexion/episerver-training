using System.Linq;
using EPiServer;
using EPiServer.DataAccess;
using EPiServer.Security;
using EPiServer.ServiceLocation;
using EpiserverSite.Models.Pages;
using EpiserverSite.Models.ViewModels;

namespace EpiserverSite.Business.UpdatePage
{
    public class UpdateArticlePageService : UpdatePageService<AddUpdateArticlePageViewModel, ArticlePage>
    {
        public override bool TryUpdate(AddUpdateArticlePageViewModel updateModel, out ArticlePage updatedPage)
        {
            updatedPage = null;

            var contentRepository = ServiceLocator.Current.GetInstance<IContentRepository>();

            var existingContentPage = contentRepository
                .GetChildren<ArticlePage>(updateModel.Parent)
                .FirstOrDefault(x => x.ContentLink.ID == updateModel.CurrentPageId);

            if (existingContentPage == default(ArticlePage))
            {
                return false;
            }

            updatedPage = (ArticlePage)existingContentPage.CreateWritableClone();

            updatedPage.MainBody = updateModel.MainBody;
            updatedPage.OpenGraphTitle = updateModel.OpenGraphTitle;
            updatedPage.Robots = updateModel.Robots;

            contentRepository.Save(updatedPage, SaveAction.Publish, AccessLevel.NoAccess);

            return true;
        }
    }
}