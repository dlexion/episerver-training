using EPiServer.Core;

namespace EpiserverSite.Business.Interfaces
{
    public interface IUpdateBasePageModel
    {
        string PageName { get; set; }

        ContentReference CurrentPageId { get; set; }

        string Robots { get; set; }

        string OpenGraphTitle { get; set; }

    }
}