using EPiServer.Core;

namespace EpiserverSite.Models.ViewModels
{
    public class PreviewViewModel
    {
        public PreviewViewModel(IContent previewContent)
            : this()
        {
            PreviewContent = previewContent;
        }

        public PreviewViewModel()
        {
            ContentArea = new ContentArea();
        }

        public IContent PreviewContent { get; set; }

        public ContentArea ContentArea { get; set; }
    }
}