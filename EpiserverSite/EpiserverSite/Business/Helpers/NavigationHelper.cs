using EPiServer;
using EPiServer.Core;
using EPiServer.ServiceLocation;
using EpiserverSite.Models.Pages;

namespace EpiserverSite.Business.Helpers
{
    [ServiceConfiguration(typeof(INavigationHelper))]
    public class NavigationHelper : INavigationHelper
    {
        private readonly IContentLoader _contentLoader;

        public NavigationHelper(IContentLoader contentLoader)
        {
            _contentLoader = contentLoader;
        }

        public PageDataCollection GetPageChildren(ContentReference rootPage)
        {
            if (rootPage == null)
            {
                return null;
            }

            var pageRef = new PageReference(rootPage);
            return new PageDataCollection(_contentLoader.GetChildren<BasePage>(pageRef));
        }
    }
}