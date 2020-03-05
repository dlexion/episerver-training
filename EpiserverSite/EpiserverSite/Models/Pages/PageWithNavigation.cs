using System.ComponentModel.DataAnnotations;
using EPiServer.DataAnnotations;
using EpiserverSite.Models.Blocks;

namespace EpiserverSite.Models.Pages
{
    [ContentType(DisplayName = "Page With Navigation", GUID = "d6a02502-4219-49e7-b2e8-6cea30f28af5", Description = "")]
    public abstract class PageWithNavigation : BasePage
    {
        [Display(
            Name = "Listing",
            Description = "",
            GroupName = "Navigation",
            Order = 100)]
        public virtual PageListingBlock Listing { get; set; }
    }
}