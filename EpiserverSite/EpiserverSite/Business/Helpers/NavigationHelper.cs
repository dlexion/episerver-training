using EPiServer;
using EPiServer.Core;
using EPiServer.ServiceLocation;

namespace EpiserverSite.Business.Helpers
{
    [ServiceConfiguration(typeof(INavigationHelper))]
    public class NavigationHelper : INavigationHelper
    {
        public PageDataCollection GetPageChildren(ContentReference rootPage)
        {
            if (rootPage == null)
            {
                return null;
            }

            var pageRef = new PageReference(rootPage);
            return DataFactory.Instance.GetChildren(pageRef);
        }
    }
}