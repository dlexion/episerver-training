using System.Net;
using System.Web.Mvc;
using EPiServer.ServiceLocation;
using EPiServer.Web.Mvc;
using EpiserverSite.Business.CreatePage;
using EpiserverSite.Business.UpdatePage;
using EpiserverSite.Models.Pages;
using EpiserverSite.Models.ViewModels;

namespace EpiserverSite.Controllers
{
    public class ArticlePageController : PageController<ArticlePage>
    {
        private readonly ICreatePageService<ArticlePage> _createArticlePageService;
        private readonly IUpdatePageService<AddUpdateArticlePageViewModel, ArticlePage> _updateArticlePageService;

        public ArticlePageController()
        {
            _createArticlePageService = ServiceLocator.Current.GetInstance<ICreatePageService<ArticlePage>>();
            _updateArticlePageService = ServiceLocator.Current.
                GetInstance<IUpdatePageService<AddUpdateArticlePageViewModel, ArticlePage>>();
        }

        public ActionResult Index(ArticlePage currentPage)
        {
            return View(new ArticlePageViewModel(currentPage));
        }

        [ValidateInput(false)]
        public ActionResult Update(AddUpdateArticlePageViewModel model)
        {
            if (model.UpdatePage)
            {
                _updateArticlePageService.TryUpdate(model, out var updatedPage);

                return View("Index", new ArticlePageViewModel(updatedPage));
            }

            if (!string.IsNullOrEmpty(model.PageName) && _createArticlePageService.TryCreate(model.PageName, model.Parent, out var newPage))
            {
                model.CurrentPageId = newPage.ContentLink.ID;
                if (_updateArticlePageService.TryUpdate(model, out var updatedPage))
                {
                    return View("Index", new ArticlePageViewModel(updatedPage));
                }
            }

            return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Can not create new page");
        }
    }
}