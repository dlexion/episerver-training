using System.Net;
using System.Web.Mvc;
using EPiServer.Web.Mvc;
using EpiserverSite.Business.Services;
using EpiserverSite.Models.Pages;
using EpiserverSite.Models.ViewModels;

namespace EpiserverSite.Controllers
{
    public class ArticlePageController : PageController<ArticlePage>
    {
        private readonly IPageService<ArticlePage, AddUpdateArticlePageViewModel> _pageService;

        public ArticlePageController(IPageService<ArticlePage, AddUpdateArticlePageViewModel> pageService)
        {
            _pageService = pageService;
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
                if (_pageService.TryUpdate(model, out var updatedPage))
                {
                    return View("Index", new ArticlePageViewModel(updatedPage));
                }
            }
            else
            {
                if (_pageService.TryCreate(model.Parent, model, out var createdPage))
                {
                    return View("Index", new ArticlePageViewModel(createdPage));
                }
            }

            return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Can not create new page");
        }
    }
}