using System.Collections.Generic;
using EPiServer.Core;

namespace EpiserverSite.Business.Helpers
{
    public interface INavigationHelper
    {
        PageDataCollection GetPageChildren(ContentReference rootPage);
    }
}