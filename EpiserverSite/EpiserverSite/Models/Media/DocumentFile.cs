using EPiServer.Core;
using EPiServer.DataAnnotations;

namespace EpiserverSite.Models.Media
{
    [ContentType(DisplayName = "DocumentFile", GUID = "a45a061a-ce75-4c99-aac1-cad304a05595", Description = "")]
    public class DocumentFile : MediaData
    {
        public virtual string Description { get; set; }
    }
}