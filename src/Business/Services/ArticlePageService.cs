using EPiServer;
using EPiServer.ServiceLocation;
using EpiserverSite.Business.Interfaces;
using EpiserverSite.Models.Pages;
using EpiserverSite.Models.ViewModels;

namespace EpiserverSite.Business.Services
{
    [ServiceConfiguration(typeof(IPageService<ArticlePage, AddUpdateArticlePageViewModel>))]
    public class ArticlePageService : PageService<ArticlePage, AddUpdateArticlePageViewModel>
    {
        public ArticlePageService(IContentRepository contentRepository) : base(contentRepository)
        {
        }

        protected override ArticlePage UpdatePageContent(IUpdateBasePageModel updateModel)
        {
            var page = base.UpdatePageContent(updateModel);

            page.MainBody = (updateModel as AddUpdateArticlePageViewModel)?.MainBody;

            return page;
        }
    }
}