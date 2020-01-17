using System.Net;
using System.Web.Mvc;
using EPiServer.Web.Mvc;
using EpiserverSite.Business;
using EpiserverSite.Models.Pages;
using EpiserverSite.Models.ViewModels;

namespace EpiserverSite.Controllers
{
    public class ArticlePageController : PageController<ArticlePage>
    {
        private readonly CreatePageService<ArticlePage> _createPageService;
        private readonly UpdatePageService<AddUpdateArticlePageViewModel, ArticlePage> _updateArticlePageService;

        public ArticlePageController()
        {
            _createPageService = new CreateArticlePageService();
            _updateArticlePageService = new UpdateArticlePageService();
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

            if (!string.IsNullOrEmpty(model.PageName) && _createPageService.TryCreate(model.PageName, model.Parent, out var newPage))
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