﻿using System.Collections.Generic;
using System.Linq;
using EPiServer;
using EPiServer.Core;
using EPiServer.ServiceLocation;
using EpiserverSite.Models;
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
            var topLevelMenuItems = _contentRepository.GetChildren<PageData>(ContentReference.RootPage)
                .SkipWhile(x => x.PageTypeName == "SysRecycleBin");

            var layout = new LayoutViewModel()
            {
                MenuItems = new List<MenuItem>()
            };

            foreach (var page in topLevelMenuItems)
            {
                var menuItem = new MenuItem()
                {
                    Link = page.LinkURL,
                    Name = page.Name
                };

                var subItems = _contentRepository.GetChildren<PageData>(page.ContentLink);

                foreach (var subItem in subItems)
                {
                    menuItem.SubItems.Add(new MenuItem()
                    {
                        Link = subItem.LinkURL,
                        Name = subItem.Name
                    });
                }

                layout.MenuItems.Add(menuItem);
            }

            return layout;
        }
    }
}