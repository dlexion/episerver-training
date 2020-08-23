using System.Collections.Generic;
using EPiServer.Core;
using EPiServer.DataAbstraction;

namespace EpiserverSite.Business.Helpers
{
    public interface IPageHelper
    {
        IEnumerable<PageType> GetAllPageTypes();

        PageDataCollection GetPagesByPageType(string pageType);
    }
}