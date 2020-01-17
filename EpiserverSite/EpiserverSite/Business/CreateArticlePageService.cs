using System.Linq;
using EPiServer;
using EPiServer.Core;
using EPiServer.DataAccess;
using EPiServer.Security;
using EPiServer.ServiceLocation;
using EpiserverSite.Models.Pages;

namespace EpiserverSite.Business
{
    public class CreateArticlePageService : CreatePageService<ArticlePage>
    {
        public override bool TryCreate(string pageName, ContentReference parent, out ArticlePage newPage)
        {
            newPage = null;

            var contentRepository = ServiceLocator.Current.GetInstance<IContentRepository>();

            var existingContentPage = contentRepository
                .GetChildren<ArticlePage>(parent)
                .FirstOrDefault(x => string.Equals(x.PageName, pageName));

            if (existingContentPage != default(ArticlePage))
            {
                return false;
            }

            newPage = contentRepository.GetDefault<ArticlePage>(parent);

            newPage.Name = pageName;

            contentRepository.Save(newPage, SaveAction.Publish, AccessLevel.NoAccess);

            return true;
        }
    }
}