using EpiserverSite.Models.Pages;

namespace EpiserverSite.Models.ViewModels
{
    public class ArticlePageViewModel : BaseViewModel<ArticlePage>
    {
        public ArticlePageViewModel(ArticlePage currentPage) : base(currentPage)
        {
            UpdateModel = new AddUpdateArticlePageViewModel()
            {
                Robots = currentPage.Robots,
                OpenGraphTitle = currentPage.OpenGraphTitle,
                MainBody = currentPage.MainBody,
                Parent = currentPage.ParentLink,
                CurrentPageId = currentPage.ContentLink
            };
        }

        public AddUpdateArticlePageViewModel UpdateModel { get; set; }
    }
}