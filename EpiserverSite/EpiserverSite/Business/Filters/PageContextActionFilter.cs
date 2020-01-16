using System.Collections.Generic;
using System.Web.Mvc;
using EPiServer;
using EPiServer.Core;
using EPiServer.ServiceLocation;
using EpiserverSite.Models;
using EpiserverSite.Models.Pages;
using EpiserverSite.Models.ViewModels;

namespace EpiserverSite.Business.Filters
{
    public class PageContextActionFilter : IResultFilter
    {
        public void OnResultExecuting(ResultExecutingContext filterContext)
        {
            var layoutModel = filterContext.Controller.ViewData.Model as IPageViewModel<BasePage>;

            if (layoutModel != null)
            {
                layoutModel.Layout = GenerateLayout();
            }
        }

        public void OnResultExecuted(ResultExecutedContext filterContext)
        {
        }

        private LayoutViewModel GenerateLayout()
        {
            var contentRepository = ServiceLocator.Current.GetInstance<IContentRepository>();

            var topLevelMenuItems = contentRepository.GetChildren<BasePage>(ContentReference.RootPage);

            var layout = new LayoutViewModel()
            {
                MenuItems = new List<MenuItem>()
            };

            foreach (var page in topLevelMenuItems)
            {
                var menuItem = new MenuItem()
                {
                    Link = page.LinkURL,
                    Name = page.Name,
                    SubItems = new List<MenuItem>()
                };

                var subItems = contentRepository.GetChildren<BasePage>(page.ContentLink);

                foreach (var subItem in subItems)
                {
                    menuItem.SubItems.Add(new MenuItem()
                    {
                        Link = subItem.LinkURL,
                        Name = subItem.Name,
                        SubItems = new List<MenuItem>()
                    });
                }

                layout.MenuItems.Add(menuItem);
            }

            return layout;
        }
    }
}