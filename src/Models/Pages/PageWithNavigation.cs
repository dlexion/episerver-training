using System.ComponentModel.DataAnnotations;
using EpiserverSite.Models.Blocks;

namespace EpiserverSite.Models.Pages
{
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