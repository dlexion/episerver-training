using System.Web.Mvc;
using System.Web.Routing;
using EPiServer.Framework;
using EPiServer.Framework.Initialization;

namespace EpiserverSite.Business.Initialization
{
    [InitializableModule]
    public class CustomRouteInitialization : IInitializableModule
    {
        public void Initialize(InitializationEngine context)
        {
            RouteTable.Routes.MapRoute(
                null,
                "custom-plugins/my-plugin",
                new { controller = "MyPlugin", action = "Index" });

            RouteTable.Routes.MapRoute(
                "ExistingPagesReport",
                "existing-pages-report/{action}",
                new { controller = "ExistingPagesReport", action = "Index" });
        }

        public void Uninitialize(InitializationEngine context)
        {
        }
    }
}