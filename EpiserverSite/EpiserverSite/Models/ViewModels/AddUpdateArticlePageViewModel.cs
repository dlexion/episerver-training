using EPiServer.Core;

namespace EpiserverSite.Models.ViewModels
{
    public class AddUpdateArticlePageViewModel : IUpdateModel
    {
        public virtual string Robots { get; set; }

        public virtual string OpenGraphTitle { get; set; }

        public virtual XhtmlString MainBody { get; set; }

        public bool UpdatePage { get; set; }

        public string PageName { get; set; }

        public ContentReference Parent { get; set; }

        public int CurrentPageId { get; set; }
    }
}