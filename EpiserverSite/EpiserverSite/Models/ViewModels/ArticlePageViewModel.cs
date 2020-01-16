using EpiserverSite.Models.Pages;

namespace EpiserverSite.Models.ViewModels
{
    public class ArticlePageViewModel : BaseViewModel<ArticlePage>
    {
        public ArticlePageViewModel(ArticlePage currentPage) : base(currentPage)
        {
        }
    }
}