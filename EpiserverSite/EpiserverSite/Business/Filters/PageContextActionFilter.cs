using System.Web.Mvc;
using EPiServer.Core;
using EpiserverSite.Business.Helpers;
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
            var layoutModel = filterContext.Controller.ViewData.Model as IPageViewModel<PageData>;

            if (layoutModel != null)
            {
                layoutModel.Layout = _layoutHelper.GenerateLayout();
            }
        }

        public void OnResultExecuted(ResultExecutedContext filterContext)
        {
        }
    }
}