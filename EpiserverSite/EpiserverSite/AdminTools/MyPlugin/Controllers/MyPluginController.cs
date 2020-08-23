using System.Web.Mvc;
using EPiServer.PlugIn;
using EpiserverSite.AdminTools.MyPlugin.Models;

namespace EpiserverSite.AdminTools.MyPlugin.Controllers
{
    [GuiPlugIn(
        Area = PlugInArea.AdminMenu,
        Url = "/plugins/MyPlugin",
        DisplayName = "My Plugin")]
    [Authorize(Roles = "WebAdmins")]
    public class MyPluginController : Controller
    {
        public ActionResult Index()
        {
            var model = new MyPluginViewModel { Text = "Lorem Ipsum Dolor" };

            return View("~/AdminTools/MyPlugin/Views/Index.cshtml", model);
        }
    }
}