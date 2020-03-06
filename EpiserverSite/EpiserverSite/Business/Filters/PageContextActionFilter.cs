using System.Web.Mvc;
using EpiserverSite.Business.Helpers;
using EpiserverSite.Models.Pages;
using EpiserverSite.Models.ViewModels;

namespace EpiserverSite.Business.Filters
{
    public class PageContextActionFilter : IResultFilter
    {
        private readonly ILayoutHelper _layoutHelper;

        public PageContextActionFilter(ILayoutHelper layoutHelper)
        {
            _layoutHelper = layoutHelper;
        }

        public void OnResultExecuting(ResultExecutingContext filterContext)
        {
            if (filterContext.Controller.ViewData.Model is IPageViewModel<BasePage> layoutModel)
            {
                layoutModel.Layout = _layoutHelper.GenerateLayout();
            }
        }

        public void OnResultExecuted(ResultExecutedContext filterContext)
        {
        }
    }
}