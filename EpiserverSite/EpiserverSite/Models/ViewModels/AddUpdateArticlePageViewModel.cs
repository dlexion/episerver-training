using EPiServer.Core;
using EpiserverSite.Business.Interfaces;

namespace EpiserverSite.Models.ViewModels
{
    public class AddUpdateArticlePageViewModel : IUpdateBasePageModel
    {
        public virtual string Robots { get; set; }

        public virtual string OpenGraphTitle { get; set; }

        public virtual XhtmlString MainBody { get; set; }

        public bool UpdatePage { get; set; }

        public string PageName { get; set; }

        public ContentReference Parent { get; set; }

        public ContentReference CurrentPageId { get; set; }
    }
}