using System.Web;
using EPiServer.Framework.Web;
using EPiServer.Web;

namespace EpiserverSite.Business.Channels
{
    public class MobileDisplayChannel : DisplayChannel
    {
        public override bool IsActive(HttpContextBase context)
        {
            return context.Request.Browser.IsMobileDevice;
        }

        public override string ChannelName => RenderingTags.Mobile;
    }
}