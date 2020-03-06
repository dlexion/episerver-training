using System.Collections.Generic;
using System.Linq;
using EPiServer;
using EPiServer.Core;
using EPiServer.ServiceLocation;
using EpiserverSite.Models;
using EpiserverSite.Models.Pages;
using EpiserverSite.Models.ViewModels;

namespace EpiserverSite.Business.Helpers
{
    [ServiceConfiguration(typeof(ILayoutHelper))]
    public class LayoutHelper : ILayoutHelper
    {
        private readonly IContentRepository _contentRepository;

        public LayoutHelper(IContentRepository contentRepository)
        {
            _contentRepository = contentRepository;
        }

        public LayoutViewModel GenerateLayout()
        {
            var layout = new LayoutViewModel();

            var startPage = _contentRepository.Get<BasePage>(ContentReference.StartPage);

            var subPages = _contentRepository.GetChildren<BasePage>(ContentReference.StartPage);
            List<MenuItem> subItems = subPages
                .Select(subItem => new MenuItem { Link = subItem.LinkURL, Name = subItem.Name })
                .ToList();

            var menuItem = new MenuItem
            {
                Link = startPage.LinkURL,
                Name = startPage.Name,
                SubItems = subItems,
            };

            layout.MenuItems.Add(menuItem);

            return layout;
        }
    }
}