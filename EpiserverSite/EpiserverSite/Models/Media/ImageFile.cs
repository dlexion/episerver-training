using EPiServer.Core;
using EPiServer.DataAnnotations;
using EPiServer.Framework.DataAnnotations;

namespace EpiserverSite.Models.Media
{
    [ContentType(DisplayName = "ImageFile", GUID = "d4c6e668-e4f7-4403-8376-0600439cd7a1", Description = "")]
    [MediaDescriptor(ExtensionString = "jpg,jpeg,jpe,ico,gif,bmp,png")]
    public class ImageFile : ImageData
    {
        public virtual string Copyright { get; set; }

        public virtual string Description { get; set; }
    }
}