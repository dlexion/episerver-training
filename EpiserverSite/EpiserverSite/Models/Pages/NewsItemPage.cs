using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;

namespace EpiserverSite.Models.Pages
{
    [AvailableContentTypes(Availability.None)]
    [ContentType(DisplayName = "News Item Page", GUID = "6a9b08dc-0774-4505-ad2f-acd939b98cec", Description = "")]
    public class NewsItemPage : PageWithNavigation
    {
        [CultureSpecific]
        [Display(
            Name = "Title",
            Description = "",
            GroupName = SystemTabNames.Content,
            Order = 10)]
        public virtual string ItemTitle { get; set; }

        [CultureSpecific]
        [Display(
            Name = "Main body",
            Description = "",
            GroupName = SystemTabNames.Content,
            Order = 20)]
        public virtual XhtmlString MainBody { get; set; }
    }
}